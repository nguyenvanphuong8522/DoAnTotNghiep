using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private Vector2 direction;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        direction = target.position - transform.position;
        rb.velocity = direction.normalized * speed;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
