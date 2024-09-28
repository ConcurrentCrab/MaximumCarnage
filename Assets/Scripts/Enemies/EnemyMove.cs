using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [SerializeField] float maxAccel;
    [SerializeField] float maxVel;
    [SerializeField] float turnVel;

    Vector3 velocity;

    void Start() {
    }

    void Update() {
    }

    public void processMove(Vector3 target) {
        Vector3 targetDir = (target - transform.position).normalized;
        enemyMove(targetDir);
    }

    void enemyMove(Vector3 dir) {
        transform.forward = Vector3.RotateTowards(transform.forward, dir, turnVel, 0f);
        Vector3 desiredVel = dir * maxVel;
        float maxVelDelta = maxAccel * Time.fixedDeltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVel.x, maxVelDelta);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVel.y, maxVelDelta);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVel.z, maxVelDelta);
        Vector3 disp = velocity * Time.fixedDeltaTime;
        transform.localPosition += disp;
    }

}
