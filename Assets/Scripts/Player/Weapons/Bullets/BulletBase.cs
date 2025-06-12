using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifetime = 3f;
    public int damage = 1;

    protected virtual void Start()
    {
        Destroy(gameObject, lifetime);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D apirly)
    {
        if (apirly.CompareTag("Enemy"))
        {
            EnemyDeath enemyDeath = apirly.GetComponent<EnemyDeath>();
            enemyDeath.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
