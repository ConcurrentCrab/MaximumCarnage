using UnityEngine;

public class CombatDirector : MonoBehaviour {

    [SerializeField] float spawnDelay;
    [SerializeField] float spawnRadius;
    [SerializeField] GameObject[] enemies;

    Transform target;
    Transform holder;
    float spawnTimer = 0f;

    void Start() {
        target = GameGlobal.game.Player.transform;
        holder = GameGlobal.game.EnemyHolder;
        spawnTimer = spawnDelay;
    }

    void Update() {
    }

    void FixedUpdate() {
        spawnTimer -= Time.fixedDeltaTime;
        if (spawnTimer <= 0f) {
            spawnEnemy();
            spawnTimer += spawnDelay;
        }
    }

    void spawnEnemy() {
        int i = Random.Range(0, enemies.Length);
        Vector3 p = getSpawnPos();
        GameObject enemy = Instantiate(enemies[i], holder);
        enemy.transform.position = p;
    }

    Vector3 getSpawnPos() {
        Quaternion q = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
        return target.position + (q * Vector3.forward * spawnRadius);
    }

}
