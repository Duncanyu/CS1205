using UnityEngine;

public class FlyDown : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        WeaponBase wb = GetComponent<WeaponBase>();
        if (wb != null && wb.IsEquipped())
        {
            return;
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        if (transform.position.y < -5.8f)
        {
            Destroy(gameObject);
        }
    }
}
