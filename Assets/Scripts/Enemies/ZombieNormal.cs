using UnityEngine;

public class ZombieNormal : MonoBehaviour {

    enum StateEnum {
        Walking,
        Attacking,
        Dead,
    }

    EnemyMove move;
    EnemyAttack attack;
    EnemyHealth health;

    Transform player;
    StateEnum state = StateEnum.Walking;

    void Start() {
        move = GetComponent<EnemyMove>();
        attack = GetComponent<EnemyAttack>();
        health = GetComponent<EnemyHealth>();

        player = GameGlobal.Player.transform;

        health.initHealth();
    }

    void Update() {
    }

    void FixedUpdate() {
        if (state != StateEnum.Dead) {
            if (health.Health <= 0f) {
                state = StateEnum.Dead;
                attack.stopAttack();
            }
        }

        Vector3 target = player.position;
        switch (state) {
        case StateEnum.Walking:
            move.processMove(target);
            attack.processAttack(target);
            if (attack.isAttacking) {
                state = StateEnum.Attacking;
            }
            break;
        case StateEnum.Attacking:
            attack.processAttack(target);
            if (!attack.isAttacking) {
                state = StateEnum.Walking;
            }
            break;
        }
    }

}
