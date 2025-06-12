using UnityEngine;

public class BasicBullet : BulletBase
{
    protected override void Start()
    {
        base.Start();
        damage = 10;
    }
}
