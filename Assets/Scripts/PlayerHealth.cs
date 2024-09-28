using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHurtable {

    [SerializeField] float healthStart;

    public float Health { get; private set; }

    void Start() {
    }

    void Update() {
    }

    public void initHealth() {
        Health = healthStart;
    }

    public void Hurt(float val) {
        Health -= val;
    }

}
