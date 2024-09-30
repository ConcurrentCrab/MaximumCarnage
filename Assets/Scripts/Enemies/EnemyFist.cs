using UnityEngine;

public class EnemyFist : MonoBehaviour {

    [SerializeField] LayerMask hurtLayer;
    [SerializeField] float hurtVal;
    [SerializeField] float knockVal;

    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter(Collider coll) {
        if (hurtLayer.Contains(coll.gameObject.layer)) {
            if (coll.gameObject.TryGetComponent(out IHurtable hurtable)) {
                hurtable.Hurt(hurtVal);
            }
            if (coll.gameObject.TryGetComponent(out IKnockable knockable)) {
                knockable.Knock((coll.gameObject.transform.position - transform.position).normalized * knockVal);
            }
        }
    }

}
