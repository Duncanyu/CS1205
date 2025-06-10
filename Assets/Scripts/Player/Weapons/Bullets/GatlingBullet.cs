using UnityEngine;

public class GatlingBullet : BulletBase
{
    protected override void Start()
    {
        base.Start();
        damage = 1;
    }
}
