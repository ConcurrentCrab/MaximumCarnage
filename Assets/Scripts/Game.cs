using UnityEngine;

public static class GameGlobal {

    public static Game game;

}

public class Game : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    [SerializeField] Transform enemyHolder;
    [SerializeField] Transform projectileHolder;

    public GameObject Player => player;

    public Camera Cam => cam;

    public Transform EnemyHolder => enemyHolder;

    public Transform ProjectileHolder => projectileHolder;

    void Start() {
        GameGlobal.game = this;
    }

    void Update() {
    }

}
