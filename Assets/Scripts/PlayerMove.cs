using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {

    [SerializeField] float maxAccel;
    [SerializeField] float maxVel;

    Vector3 velocity = Vector3.zero;
    Vector2 inputDir = Vector2.zero;

    void Start() {
    }

    void Update() {
    }

    void FixedUpdate() {
        playerMove();
    }

    void playerMove() {
        Vector3 desiredVel = new Vector3(inputDir.x, 0f, inputDir.y) * maxVel;
        float maxVelDelta = maxAccel * Time.fixedDeltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVel.x, maxVelDelta);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVel.y, maxVelDelta);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVel.z, maxVelDelta);
        Vector3 disp = velocity * Time.fixedDeltaTime;
        transform.localPosition += disp;
    }

    void OnInputMove(InputValue value) {
        inputDir = Vector2.ClampMagnitude(value.Get<Vector2>(), 1.0f);
    }

}
