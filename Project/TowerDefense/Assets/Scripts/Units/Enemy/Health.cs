using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, Ihealth
{
    public CircleCollider2D circleCollider;
    public EnemyName enemyName;
    public int coin;
    public float health { get; set; }
    public HealBar healBar { get; set ; }

    private void OnEnable()
    {
        Init();
    }
    private void Update()
    {
        if (health <= 0)
        {
            SetDie();
        }
    }
    private void Init()
    {
        int index = (int)enemyName;
        healBar = GetComponent<HealBar>();
        health = GameManager.instance.enemiesData.enemies[index].health;
        EnableCollider();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healBar.UpdateHealBar();
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
    public void ReduceHealth()
    {
        LevelManager.instance.curLevel.ReduceHeal();
    }
    private void SetDie()
    {
        EnableCollider(false);
        LevelManager.instance.curLevel.IncreaseCoin(coin);
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
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.enemyDies[index], transform.position, 0.7f);
        die.transform.up = transform.GetChild(0).up;
    }

}
