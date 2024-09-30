using UnityEngine;

public class Pistol : WeaponBase {

    [SerializeField] int roundsFull;
    [SerializeField] float shootTime;
    [SerializeField] float reloadTime;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Vector3 bulletSpawn;

    int rounds = 0;
    float shootTimer = 0f;
    float reloadTimer = 0f;

    void Start() {
        reload();
    }

    void Update() {
    }

    private void OnDrawGizmosSelected() {
        Vector3 spawnWorld = transform.TransformPoint(bulletSpawn);
        Gizmos.DrawSphere(spawnWorld, 0.1f);
    }

    void FixedUpdate() {
        shootTimer = Mathf.Clamp(shootTimer - Time.fixedDeltaTime, 0f, shootTime);
        reloadTimer = Mathf.Clamp(reloadTimer - Time.fixedDeltaTime, 0f, reloadTime);
    }

    public override void Fire() {
        if (shootTimer > 0f || reloadTimer > 0f) {
            // empty fire
            return;
        }
        spawnBullet();
        rounds -= 1;
        if (rounds > 0) {
            shootTimer = shootTime;
        } else {
            reload();
        }
    }

    void reload() {
        reloadTimer = reloadTime;
        rounds = roundsFull;
    }

    void spawnBullet() {
        Vector3 spawnWorld = transform.TransformPoint(bulletSpawn);
        GameObject bullet = Instantiate(bulletPrefab, GameGlobal.game.ProjectileHolder);
        bullet.transform.position = spawnWorld;
        bullet.transform.forward = transform.forward;
    }

}
