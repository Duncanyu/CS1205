using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float health = 1;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Instance.AddPoints(1);
        Destroy(gameObject); // destroy the enemy
    }
}
