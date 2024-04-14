using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public CircleCollider2D circleCollider;
    private void OnEnable()
    {
        Init();
    }
    private void Init()
    {
        int index = (int)EnemyName.SmallSolider;
        health = GameManager.instance.enemiesData.enemies[index].health;
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

    public void ReturnToPool()
    {
        WaveManager.instance.curWave.ReduceCountEnemy();
        ObjectPool.instance.Return(gameObject);
    }
    private void SetDie()
    {
        SpawnEffectDie();
        ReturnToPool();
    }
    private void EnableCollider(bool value = true)
    {
        GetComponent<Collider>().isTrigger = value;
    }
    private void SpawnEffectDie()
    {
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.enemyDies[0], transform.position);
        die.transform.up = transform.GetChild(0).up;
    }
}
