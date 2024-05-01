using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSnipperMovement : ProjectileMovement
{
    public override void FixedUpdate()
    {
        Move();
    }
    protected override void Rotate()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
