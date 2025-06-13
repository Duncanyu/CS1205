// using UnityEngine;
// using static UnityEngine.UI.Image;
// using UnityEngine.UIElements;

using UnityEngine;

public class Weapon2 : WeaponBase
{


    
        public Transform player;
        public GameObject playerPrefab;
        public GameObject bulletPrefab;
       
        public float bulletSpeed = 10f;

        private void Start()
        {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        SetOwner(player);
       
        }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            {
                Fire(Vector2.Lerp(Vector2.left, Vector2.right,0.1f)); // Pass a proper direction
            }
        }
    }

        protected override void Shoot(Vector2 direction)
        {
            if (player == null)
            {
                Debug.LogWarning("No player transform");
                return;
            }

            GameObject bullet = Instantiate(bulletPrefab, player.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = direction.normalized * bulletSpeed;
            }

            bullet.transform.up = direction;
        }

        public override void Fire(Vector2 direction)
        {
            if (Time.time >=fireRate)
            {
                
                Shoot(direction);
            }
        }

    
}



