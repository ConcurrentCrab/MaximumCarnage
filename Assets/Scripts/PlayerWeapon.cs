using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour {

    [System.Serializable]
    struct WeaponPair {
        public WeaponsEnum name;
        public GameObject weapon;
    }

    [SerializeField] WeaponPair[] weapons;
    [SerializeField] WeaponsEnum startingWeapon;

    WeaponBase currentWeapon;

    float inputFire = 0f;

    void Start() {
        switchWeapon(startingWeapon);
    }

    void Update() {
    }

    private void FixedUpdate() {
        if (inputFire > 0f) {
            currentWeapon.Fire();
        }
        inputFire = 0f;
    }

    public void switchWeapon(WeaponsEnum to) {
        currentWeapon = null;
        for (int i = 0; i < weapons.Length; i++) {
            if (weapons[i].name == to) {
                weapons[i].weapon.SetActive(true);
                currentWeapon = weapons[i].weapon.GetComponent<WeaponBase>();
            } else {
                weapons[i].weapon.SetActive(false);
            }
        }
    }

    void OnInputFire(InputValue value) {
        inputFire = value.Get<float>();
    }

}
