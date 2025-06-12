using UnityEngine;

public class LaserWeapon : WeaponBase
{
    public LineRenderer laserLine;
    public float damagePerSecond = 10f;
    public float maxDistance = 20f;
    public GameObject particleEffects;

    void Start()
    {
        Physics2D.queriesHitTriggers = true;

        if (laserLine != null)
        {
            laserLine.positionCount = 2;
            laserLine.enabled = false;
        }
    }

    void Update()
    {
        if (playerTransform == null || laserLine == null)
            return;

        bool holdingFire = Input.GetKey(KeyCode.Space);

        if (holdingFire)
        {
            Shoot(Vector2.up);
        }
        else
        {
            laserLine.enabled = false;
        }
    }

    protected override void Shoot(Vector2 direction)
    {
        Vector2 origin = playerTransform.position;
        direction = Vector2.up;

        laserLine.enabled = true;
        laserLine.SetPosition(0, origin);
        laserLine.SetPosition(1, origin + direction * maxDistance);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, maxDistance);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider == null || hit.collider.CompareTag("Player"))
                continue;

            laserLine.SetPosition(1, hit.point); // stop beam at hit point

            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyDeath enemy = hit.collider.GetComponent<EnemyDeath>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damagePerSecond * Time.deltaTime);
                    Debug.Log("Laser hit enemy: Pew boom!");
                }
            }

            if (particleEffects != null)
            {
                Vector3 endPoint = hit.point;
                GameObject impactEffect = Instantiate(particleEffects, endPoint, Quaternion.identity);

                ParticleSystem ps = impactEffect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    Destroy(impactEffect, ps.main.duration + ps.main.startLifetime.constantMax);
                }
                else
                {
                    Destroy(impactEffect, 0.2f);
                }
            }

            break;
        }

        float beamLength = Vector2.Distance(laserLine.GetPosition(0), laserLine.GetPosition(1));
        if (laserLine.material != null)
        {
            laserLine.material.mainTextureScale = new Vector2(beamLength, 1f);
        }
    }
}
