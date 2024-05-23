using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 curTarget;
    [SerializeField] private float speed;
    private Vector2[] path;
    private int curIndex = 0;
    [SerializeField] private Transform sprite;
    public Health health;
    private float stepMove { get => speed * Time.fixedDeltaTime; }
    public void Init()
    {
        curIndex = 0;
        curTarget = path[curIndex];
        transform.position = curTarget;
        InitSpeed();
        RotateFace();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        RotateFace();
    }
    private void Move()
    {
        if (curIndex > path.Length - 1)
        {
            health.ReduceHealth();
            health.ReturnToPool();
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
            return;
        }
        rb.MovePosition(curTarget);
        NextTarget();
        float offset = stepMove - distance;
        rb.MovePosition(rb.position + directionToward * offset);
    }
    private void NextTarget()
    {
        curIndex++;
        if (curIndex < path.Length)
        {
            curTarget = path[curIndex];
            
        }
    }
    private void RotateFace()
    {
        Vector3 look = (Vector3)curTarget - transform.position;
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        sprite.rotation = Quaternion.Lerp(sprite.rotation, Quaternion.Euler(0, 0, angle), 0.1f);
    }
    public void SetPath(Path path)
    {
        this.path = path.path;
    }
    public void Teleport()
    {
        health.EnableCollider(false);
        curIndex = 0;
        curTarget = path[curIndex];
        transform.position = path[curIndex];
        health.EnableCollider();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Teleport"))
        {
            Teleport();
        }
        else if(col.CompareTag("TimeWraper"))
        {
            TowerAttackTimer towerAttack = col.GetComponentInParent<TowerAttackTimer>();
            if (towerAttack == null) return;
            Slow(towerAttack.percentSlow);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("TimeWraper"))
        {
            InitSpeed();
        }
    }
    public void InitSpeed()
    {
        int index = (int)health.enemyName;
        speed = GameManager.instance.enemiesData.enemies[index].speedMove;
    }

    private void Slow(float value)
    {
        speed -= speed * (value * 0.01f);
    }
}
