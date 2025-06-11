using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class Weapon2 : WeaponBase
{
    public GameObject bulletPrefab;
    private float _randomFireRate;

    private void Awake()
    {
        _randomFireRate = Random.Range(0.1f, 5f); 
    }

    protected override void Shoot(Vector2 direction)
    {
       
        if (playerTransform == null)
        {
            Debug.LogWarning("no playetreansform set.");
            return;
        }
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(
        playerTransform.position.x,
        playerTransform.position.y - 3,
        playerTransform.position.z
    ), Quaternion.identity);
    }


    public override void Fire(Vector2 direction) {
        if (Time.time >= lastFiredTime + _randomFireRate)
        {


            lastFiredTime = Time.time;
            Shoot(direction);
        }
    }
    

}
 

