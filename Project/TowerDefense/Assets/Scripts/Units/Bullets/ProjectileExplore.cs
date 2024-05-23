using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplore : MonoBehaviour
{
    private ObjectPool objectPool;
    [SerializeField] private Rigidbody2D rb;
    [HideInInspector]public int damage;
    [SerializeField] private TrailRenderer trailRenderer;
    private void Start()
    { 
        objectPool = ObjectPool.instance;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Bound"))
        {
            Explore();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bound"))
        {
            Explore();
        }
    }

    public void Explore()
    {
        ResetValueBullet();
        trailRenderer.Clear();
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
