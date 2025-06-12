using UnityEngine;

public class ShotgunWeapon : WeaponBase
{
    public GameObject bulletPrefab;
    public int pelletCount = 6;
    public float maxSpreadAngle = 20f; //.degrees

    protected override void Shoot(Vector2 _ignored)
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("npts");
            return;
        }

        Vector2 baseDirection = Vector2.up;
        float baseAngle = 90f;

        for (int i = 0; i < pelletCount; i++)
        {
            //------
            float randomOffset = Random.Range(-maxSpreadAngle, maxSpreadAngle);
            float angle = baseAngle + randomOffset;
            float rad = angle * Mathf.Deg2Rad;

            Vector2 spreadDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
            //------

            GameObject bullet = Instantiate(bulletPrefab, playerTransform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = spreadDirection * 10f;
            }

            bullet.transform.up = spreadDirection;
        }
    }
}
