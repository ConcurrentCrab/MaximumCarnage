using UnityEngine;

public class Player : MonoBehaviour {

    enum StateEnum {
        Normal,
        Dead,
    }

    PlayerMove move;
    PlayerAim aim;
    PlayerWeapon weapon;
    PlayerHealth health;

    StateEnum state = StateEnum.Normal;

    public bool isAlive => state != StateEnum.Dead;

    void Start() {
        move = GetComponent<PlayerMove>();
        aim = GetComponent<PlayerAim>();
        weapon = GetComponent<PlayerWeapon>();
        health = GetComponent<PlayerHealth>();

        weapon.initWeapon();
        health.initHealth();
    }

    void Update() {
    }

    private void FixedUpdate() {
        if (state != StateEnum.Dead) {
            if (health.Health <= 0f) {
                state = StateEnum.Dead;
            }
        }

        switch (state) {
        case StateEnum.Normal:
            move.processMove();
            aim.processAim();
            weapon.processWeapon();
            break;
        }
    }

}
