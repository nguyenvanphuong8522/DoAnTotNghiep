using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    private Vector3 direction;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        //direction = target.position - transform.position;
        direction = transform.right;
        rb.velocity = direction * speed;
    }
}
