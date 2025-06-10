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
        Destroy(gameObject, lifetime); //start the countdown!!
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

        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
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
            Destroy(gameObject);
            //ryan or future duncan please make it kill the bad guy or reduce hp.
        }
    }
}
