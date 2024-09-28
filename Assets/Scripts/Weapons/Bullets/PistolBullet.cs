using UnityEngine;

public class PistolBullet : MonoBehaviour {

    [SerializeField] LayerMask hurtLayer;
    [SerializeField] float hurtVal;

    public Vector3 velocity { get; set; }

    void Start() {
    }

    void Update() {
    }

    void FixedUpdate() {
        transform.localPosition += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider coll) {
        if (hurtLayer.Contains(coll.gameObject.layer) && coll.gameObject.TryGetComponent(out IHurtable hurtable)) {
            hurtable.Hurt(hurtVal);
            Destroy(gameObject);
        }
    }

}
