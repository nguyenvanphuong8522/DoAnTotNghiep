using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplore : MonoBehaviour
{
    private ObjectPool objectPool;
    [SerializeField] private Rigidbody2D rb;
    private void Start()
    {
        objectPool = ObjectPool.instance;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Explore();
        }
    }

    private void Explore()
    {
        ResetValueBullet();
        objectPool.Return(gameObject);
    }
    private void ResetValueBullet()
    {
        rb.velocity = Vector3.zero;
    }
    private void OnValidate()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
}
