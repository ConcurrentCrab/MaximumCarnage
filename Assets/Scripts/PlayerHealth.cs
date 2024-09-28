using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHurtable {

    [SerializeField] float health;

    void Start() {
    }

    void Update() {
    }

    void FixedUpdate() {
        if (health <= 0f) {
            die();
        }
    }

    public void Hurt(float val) {
        health -= val;
    }

    void die() {
        Destroy(gameObject);
    }

}
