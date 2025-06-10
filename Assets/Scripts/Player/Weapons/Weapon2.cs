using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class Weapon2 : WeaponBase
{
    public GameObject bulletPrefab;

    protected override void Shoot(Vector2 direction)
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("no playetreansform set.");
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, Vector3, Quaternion rotation, Transform parent);
    }

    public override void Fire(Vector2 direction)
    {
       
    }
}
 

