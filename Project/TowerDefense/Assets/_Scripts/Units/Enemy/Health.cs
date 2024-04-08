using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public CircleCollider2D circleCollider;

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ReturnToPool();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }

    private void ReturnToPool()
    {
        SpawnEffectDie();
        Destroy(gameObject);
    }

    private void EnableCollider(bool value = true)
    {
        GetComponent<Collider>().isTrigger = value;
    }
    private void SpawnEffectDie()
    {
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.pools[1], transform.position, 0.5f);
        die.transform.up = transform.GetChild(0).up;
    }
}
