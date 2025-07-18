using UnityEngine;

//i changed it so that its just gonna be logic only no more visual weapon idea thats too much for me to do today

public class WeaponBase : MonoBehaviour
{
    public float fireRate = 0.5f;
    public GameObject weaponPrefab;
    private bool isEquipped = false;
    protected float lastFiredTime = 0f;

    protected Transform playerTransform;

        public void SetOwner(Transform player)
        {
            playerTransform = player;
        }

    public bool IsEquipped()
    {
        return isEquipped;
    }

    public void ToggleEquipped()
    {
        isEquipped = !isEquipped;
    }

    public virtual void Fire(Vector2 direction)
    {
        if (Time.time >= lastFiredTime + fireRate)
        {
            lastFiredTime = Time.time;
            Shoot(direction);
        }
    }

    protected virtual void Shoot(Vector2 direction)
    {
        Debug.Log("Pew");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponsHandler wh = collision.GetComponent<WeaponsHandler>();
            wh.EquipWeapon(weaponPrefab);
            Destroy(gameObject);
        }
    }
}
