using UnityEngine;

public static class GameGlobal {

    public static GameObject Player;
    public static Camera Cam;
    public static Transform ProjectileHolder;

}

public class Game : MonoBehaviour {

    [SerializeField] GameObject Player;
    [SerializeField] Camera Cam;
    [SerializeField] Transform ProjectileHolder;

    void Start() {
        GameGlobal.Player = Player;
        GameGlobal.Cam = Cam;
        GameGlobal.ProjectileHolder = ProjectileHolder;
    }

    void Update() {
    }

}
