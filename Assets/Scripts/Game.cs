using UnityEngine;

public static class GameGlobal {

    public static GameObject Player;

    public static Transform ProjectileHolder;

}

public class Game : MonoBehaviour {

    [SerializeField] GameObject Player;
    [SerializeField] Transform ProjectileHolder;

    void Start() {
        GameGlobal.Player = Player;
        GameGlobal.ProjectileHolder = ProjectileHolder;
    }

    void Update() {
    }

}
