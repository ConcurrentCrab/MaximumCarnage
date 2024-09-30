using UnityEngine;

public class PistolBullet : MonoBehaviour {

    [SerializeField] LayerMask hurtLayer;
    [SerializeField] float hurtVal;
    [SerializeField] float knockVal;

    public Vector3 velocity { get; set; }

    void Start() {
    }

    void Update() {
    }

    void FixedUpdate() {
        transform.localPosition += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider coll) {
        if (hurtLayer.Contains(coll.gameObject.layer)) {
            if (coll.gameObject.TryGetComponent(out IHurtable hurtable)) {
                hurtable.Hurt(hurtVal);
            }
            if (coll.gameObject.TryGetComponent(out IKnockable knockable)) {
                knockable.Knock((coll.gameObject.transform.position - transform.position).normalized * knockVal);
            }
            Destroy(gameObject);
        }
    }

}
