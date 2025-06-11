using UnityEngine;

public class MissileAddonCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponsHandler wh = collision.GetComponent<WeaponsHandler>();
            wh.ActivateMissiles();
            Destroy(gameObject);
        }
    }
}
