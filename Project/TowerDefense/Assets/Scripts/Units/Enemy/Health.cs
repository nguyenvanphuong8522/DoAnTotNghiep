using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour, Ihealth
{
    public CircleCollider2D circleCollider;
    public EnemyName enemyName;
    public int coin;
    public Transform sprite;
    public float health { get; set; }
    public HealBar healBar { get; set ; }
    public ParticleSystem effectTakeDame;

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
                if(!effectTakeDame.isPlaying)
                {
                    effectTakeDame.Play();
                }
                TakeDamage(bulletExplore.damage);
                bulletExplore.Explore();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boom"))
        {
            TakeDamage(5500);
        }
        else if(col.gameObject.CompareTag("Bullet"))
        {
            ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
            if (bulletExplore != null)
            {
                effectTakeDame.Play();
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

        die.transform.up = sprite.up;
        SpawnDollarEffect();
    }
    private void SpawnDollarEffect()
    {
        GameObject effect = ObjectPool.instance.Get(ObjectPool.instance.effectDollar);
        effect.GetComponent<EffectDollar>().SetText(coin);
        effect.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        effect.transform.localScale = Vector3.one * 0.1f;
        effect.SetActive(true);
    }

}
