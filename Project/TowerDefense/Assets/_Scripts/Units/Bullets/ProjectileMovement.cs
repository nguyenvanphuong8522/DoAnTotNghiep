using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private ProjectileExplore explore;
    private Vector2 direction;
    public Transform sprite;

    private void FixedUpdate()
    {
        if (target.gameObject.activeSelf)
        {
            direction = target.position - transform.position;
        }
        Move();
    }
    private void Move()
    {
        Rotate();
        rb.velocity = direction.normalized * speed;
    }
    public void Rotate()
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
