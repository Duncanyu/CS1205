using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public float fireRate = 0.5f;
    protected float lastFiredTime = 0f;

    public virtual void Fire(Vector2 direction)
    {
        if (Time.time >= lastFiredTime + fireRate)
        {
            lastFiredTime = Time.time;
            Shoot(direction);
        }
    }

    public void Shoot(Vector2 direction)
    {
        //continue later
    }
}