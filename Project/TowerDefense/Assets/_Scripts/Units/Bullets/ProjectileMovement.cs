using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;
    protected Vector2 direction;
    public Transform sprite;

    public virtual void FixedUpdate()
    {
        UpdateDirection();
        Rotate();
        Move();
    }
    public virtual void Move()
    {
        rb.velocity = direction.normalized * speed;
    }
    protected void UpdateDirection()
    {
        if (target == null) return;
        if (target.gameObject.activeSelf)
        {
            direction = target.position - transform.position;
        }
    }
    protected virtual void Rotate()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        sprite.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        direction = target.position - transform.position;
        Rotate();
    }
}
