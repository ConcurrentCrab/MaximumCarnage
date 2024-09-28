using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    [SerializeField] float attackRange;
    [SerializeField] float attackTime;
    [SerializeField] GameObject fist;

    float attackTimer = 0f;

    void Start() {
    }

    void Update() {
    }

    void FixedUpdate() {
        attackTimer = Mathf.Clamp(attackTimer - Time.fixedDeltaTime, 0f, attackTime);
    }

    public void initAttack() {
        stopAttack();
    }

    public void processAttack(Vector3 target) {
        if (isAttacking) {
            return;
        }
        stopAttack();
        if (isInRange(target)) {
            attack();
        }
    }

    public bool isInRange(Vector3 target) {
        return (transform.position - target).magnitude < attackRange;
    }

    public bool isAttacking => attackTimer != 0f;

    public void attack() {
        attackTimer = attackTime;
        fist.SetActive(true);
    }

    public void stopAttack() {
        fist.SetActive(false);
    }

}
