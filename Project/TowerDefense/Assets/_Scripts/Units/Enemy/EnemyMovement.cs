using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 curTarget;
    [SerializeField] private float speed;
    private Vector2[] path;
    private int curIndex = 0;
    [SerializeField] private Transform sprite;
    private float stepMove { get => speed * Time.fixedDeltaTime; }
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        curTarget = path[curIndex];
        RotateFace();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (curIndex > path.Length - 1)
        {
            return;
        }
        GetVelocity();
    }
    private void GetVelocity()
    {
        float distance = Vector2.Distance(rb.position, curTarget);
        Vector2 directionToward = (curTarget - rb.position).normalized;
        
        if (distance >= stepMove)
        {
            Vector2 dir = directionToward * stepMove;
            rb.MovePosition(rb.position + dir);
        }
        else
        {
            rb.MovePosition(curTarget);
            NextTarget();
            float offset = stepMove - distance;
            rb.MovePosition(rb.position + directionToward * offset);
        }
    }
    private void NextTarget()
    {
        curIndex++;
        if (curIndex < path.Length)
        {
            curTarget = path[curIndex];
            RotateFace();
        }
    }
    private void RotateFace()
    {
        sprite.up = (Vector3)curTarget - transform.position;
    }
    public void SetPath(Vector2[] path)
    {
        this.path = path;
    }
}
