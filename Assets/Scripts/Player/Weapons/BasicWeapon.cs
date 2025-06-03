using UnityEngine;

public class BasicWeapon : WeaponBase
{
    public GameObject bulletPrefab;

    protected override void Shoot(Vector2 direction)
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("no playetreansform set.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, playerTransform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f;
        }
    }
}
