using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {

    public abstract void Fire();

}

public enum WeaponsEnum {
    None,
    Pistol,
}
