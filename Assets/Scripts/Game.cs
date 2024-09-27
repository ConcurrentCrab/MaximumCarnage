using UnityEngine;

public static class GameGlobal {

    public static Transform ProjectileHolder;

}

public class Game : MonoBehaviour {

    [SerializeField] Transform ProjectileHolder;

    void Start() {
        GameGlobal.ProjectileHolder = ProjectileHolder;
    }

    void Update() {
    }

}
