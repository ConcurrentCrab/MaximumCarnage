using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {

    [SerializeField] float maxAccel;
    [SerializeField] float maxVel;
    [SerializeField] float dashVel;
    [SerializeField] float dashTime;
    [SerializeField] float dashCooldown;

    Vector3 velocity = Vector3.zero;
    float dashTimer = 0f;
    float dashCooldownTimer = 0f;

    Vector2 inputDir = Vector2.zero;
    float inputDash = 0f;

    void Start() {
    }

    void Update() {
    }

    void FixedUpdate() {
        if (inputDash > 0f && dashCooldownTimer == 0f) {
            dashTimer = dashTime;
            dashCooldownTimer = dashCooldown;
            inputDash = 0f;
        }
        if (dashTimer > 0f) {
            playerDash();
        } else {
            playerMove();
        }
        dashTimer = Mathf.Clamp(dashTimer - Time.fixedDeltaTime, 0f, dashTime);
        dashCooldownTimer = Mathf.Clamp(dashCooldownTimer - Time.fixedDeltaTime, 0f, dashCooldown);
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

    void playerDash() {
        Vector3 dashDir = new Vector3(inputDir.x, 0f, inputDir.y);
        Vector3 disp = dashVel * Time.fixedDeltaTime * dashDir;
        transform.localPosition += disp;
    }

    void OnInputMove(InputValue value) {
        inputDir = Vector2.ClampMagnitude(value.Get<Vector2>(), 1.0f);
    }

    void OnInputDash(InputValue value) {
        inputDash = value.Get<float>();
    }

}
