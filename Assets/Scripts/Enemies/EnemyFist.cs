using UnityEngine;

public class EnemyFist : MonoBehaviour {

    [SerializeField] LayerMask hurtLayer;
    [SerializeField] float hurtVal;

    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter(Collider coll) {
        if (hurtLayer.Contains(coll.gameObject.layer) && coll.gameObject.TryGetComponent(out IHurtable hurtable)) {
            hurtable.Hurt(hurtVal);
        }
    }

}
