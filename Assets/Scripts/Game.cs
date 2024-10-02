using System;
using System.Threading.Tasks;
using UnityEngine;

public static class GameGlobal {

    public static Game game;

}

public class Game : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;
    [SerializeField] Transform enemyHolder;
    [SerializeField] Transform projectileHolder;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] float gameOverDelay;

    int score = 0;
    PlayerHealth health;
    bool isPlayerDead = false;

    public GameObject Player => player;

    public Camera Cam => cam;

    public Transform EnemyHolder => enemyHolder;

    public Transform ProjectileHolder => projectileHolder;

    public int Score => score;

    public bool IsPlayerDead => isPlayerDead;

    void Start() {
        GameGlobal.game = this;
        health = player.GetComponent<PlayerHealth>();
    }

    void Update() {
    }

    void FixedUpdate() {
        if (isPlayerDead) {
            return;
        }
        if (health.Health <= 0f) {
            isPlayerDead = true;
            gameOver();
        }
    }

    void gameOver() {
        new Action(async () => {
            await Task.Delay((int)(1000 * gameOverDelay));
            gameOverScreen.SetActive(true);
        })();
    }

    public void scoreIncr() {
        score++;
    }

}
