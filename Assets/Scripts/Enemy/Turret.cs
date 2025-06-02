using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform player;
    public float fireRate = 2f;
    public float detectionRange = 6f;

    private float fireCooldown = 0f;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= detectionRange)
        {
            if (fireCooldown <= 0f)
            {
                Fire();
                fireCooldown = 1f / fireRate;
                Debug.Log(distance);
            }
        }

        fireCooldown -= Time.deltaTime;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 dir = (player.position - firePoint.position);
        bullet.GetComponent<Bullet>().SetDirection(dir);
    }
}