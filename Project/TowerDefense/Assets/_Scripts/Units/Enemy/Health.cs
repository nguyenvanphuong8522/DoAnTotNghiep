using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public CircleCollider2D circleCollider;
    public EnemyName enemyName;
    private void OnEnable()
    {
        Init();
    }
    private void Init()
    {
        int index = (int)enemyName;
        health = GameManager.instance.enemiesData.enemies[index].health;
        EnableCollider();
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SetDie();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
            if (bulletExplore != null)
            {
                TakeDamage(bulletExplore.damage);
                bulletExplore.Explore();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boom"))
        {
            TakeDamage(10);
        }
        else if(col.gameObject.CompareTag("Bullet"))
        {
            ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
            if (bulletExplore != null)
            {
                TakeDamage(bulletExplore.damage);
            }
        }
    }
    public void ReturnToPool()
    {
        WaveManager.instance.curWave.ReduceCountEnemy();
        ObjectPool.instance.Return(gameObject);
    }
    private void SetDie()
    {
        EnableCollider(false);
        SpawnEffectDie();
        ReturnToPool();
    }
    public void EnableCollider(bool value = true)
    {
        circleCollider.enabled = value;
    }
    private void SpawnEffectDie()
    {
        int index = (int)enemyName;
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.enemyDies[index], transform.position);
        die.transform.up = transform.GetChild(0).up;
    }
}
