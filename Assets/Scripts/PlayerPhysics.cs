using UnityEngine;

public class PlayerPhysics : MonoBehaviour, IKnockable {

    [SerializeField] float mass;
    [SerializeField] float drag;
    [SerializeField] float dragVel;

    Vector3 acceleration = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    void Start() {
    }

    void Update() {
    }

    public void processPhysics() {
        playerMove();
    }

    void playerMove() {
        acceleration *= 1 - drag;
        velocity += acceleration * Time.fixedDeltaTime;
        velocity *= 1 - dragVel;
        transform.localPosition += velocity * Time.fixedDeltaTime;
    }

    void applyAcceleration(Vector3 a) {
        acceleration += a;
    }

    void applyForce(Vector3 f) {
        applyAcceleration(f / mass);
    }

    public void Knock(Vector3 f) {
        f.y = 0f;
        applyForce(f);
    }

}
