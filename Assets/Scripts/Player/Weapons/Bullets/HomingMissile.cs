using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [Header("Missile Settings")]
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public float lifetime = 5f;

    private Transform target;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        //----- BEWARE ----- FOR THE CODE BELOW IS NOT MINE
        Vector2 direction = (target.position - transform.position).normalized;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.up * speed * Time.deltaTime;
        //----- DON'T WORRY ----- THE REST IS MINE
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    private void OnTriggerEnter2D(Collider2D apirly)
    {
        if (apirly.transform == target || apirly.CompareTag("Enemy"))
        {
            //KABLOOEY
            EnemyDeath enemyDeath = apirly.GetComponent<EnemyDeath>();
            enemyDeath.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
