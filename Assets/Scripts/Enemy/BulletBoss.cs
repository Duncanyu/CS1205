using UnityEngine;

public class MultiFireTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] firePoints;
    public float fireRate = 2f;
    public float detectionRange = 6f;

    private Transform player;
    private float fireCooldown = 0f;

    public int bulletCount = 10; // For random spread

    private EnemyDeath bossHealth;

    void Start()
    {
        bossHealth = GetComponentInParent<EnemyDeath>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            AimAtPlayer();

            if (fireCooldown <= 0f)
            {
                Debug.Log(bossHealth.health);

                if (bossHealth.health <= bossHealth.health / 2) {
                    FireAll();
                } else {
                    FireRandomSpread();
                }
                //FireRandomSpread();
                fireCooldown = 1f / fireRate;
            }
        }

        fireCooldown -= Time.deltaTime;
    }

    void AimAtPlayer()
    {
        Vector2 aimDirection = player.position - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FireRandomSpread()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float randomAngle = Random.Range(-30f, 30f); // Degrees offset from downward
            float finalAngle = -90f + randomAngle; // So it's centered downward

            // Convert angle to a direction vector
            float radians = finalAngle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

            // Spawn bullet at each fire point (or just one)
            GameObject bullet = Instantiate(bulletPrefab, firePoints[0].position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(direction);
            }
        }
    }

    void FireAll()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Vector2 dir = (player.position - firePoint.position).normalized;

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(dir);
            }
        }
    }
}
