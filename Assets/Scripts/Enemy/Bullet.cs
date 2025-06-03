using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;

    private Vector2 direction;

    // public void SetDirection(Vector2 dir)
    // {
    //     direction = dir.normalized;
    //     Destroy(gameObject, lifeTime); // destroy after a few seconds
    // }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    // void OnBecameInvisible()
    // {
    //     Destroy(gameObject);
    // }

    public void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        Destroy(gameObject, lifeTime); // destroy after a few seconds
    }

}
