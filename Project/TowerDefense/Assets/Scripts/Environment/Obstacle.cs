using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, Ihealth
{
    public Animator animator;
    public List<TowerAttack> towerAttacks;
    public bool isUnderAttack = false;

    public float health { get; set; }

    private void OnEnable()
    {
        towerAttacks.Clear();
        isUnderAttack = false;
        health = 100;
        GameEvent.returnLevel += ReturnToPool;
    }
    private void Update()
    {
        if (health <= 0)
        {
            SetDie();
        }
    }
    private void OnMouseUp()
    {
        if (!Utils.IsPointerOverUIElement())
            CheckStartShootObstacles();
    }
    public void CheckStartShootObstacles()
    {
        isUnderAttack = !isUnderAttack;
        if (towerAttacks.Count > 0)
        {
            foreach (TowerAttack element in towerAttacks)
            {
                CheckIsShootObstacle(element);
            }
        }
    }

    public void CheckIsShootObstacle(TowerAttack towerAttack)
    {
        towerAttack.ShootObstacle(transform, !towerAttack.gun.isShootingObstacle);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Bullet")) return;

        ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
        if (bulletExplore != null)
        {
            TakeDamage(bulletExplore.damage);
            bulletExplore.Explore();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        AddOrRemove(col);

        if (!col.gameObject.CompareTag("Bullet")) return;

        ProjectileExplore bulletExplore = col.gameObject.GetComponent<ProjectileExplore>();
        if (bulletExplore != null)
        {
            TakeDamage(bulletExplore.damage);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        AddOrRemove(col, false);
    }

    private void AddOrRemove(Collider2D col, bool value = true)
    {
        if (!col.CompareTag("Tower")) return;

        TowerAttack towerAttack = col.gameObject.GetComponentInParent<TowerAttack>();
        if (towerAttack == null) return;

        if (value)
        {
            AddTowerAttack(towerAttack);
            return;
        }
        towerAttacks.Remove(towerAttack);
    }
    private void AddTowerAttack(TowerAttack towerAttack)
    {
        towerAttacks.Add(towerAttack);
        if (isUnderAttack)
        {
            towerAttack.ShootObstacle(transform);
        }
    }

    private void SetDie()
    { 
        CheckDie();
        SpawnEffectDie();
        ReturnToPool();
    }
    public void CheckDie()
    {
        if (isUnderAttack)
        {
            foreach (TowerAttack element in towerAttacks)
            {
                element.ShootObstacle(transform, false);
            }
        }
    }
    private void SpawnEffectDie()
    {
        Debug.Log("die");
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.obstacleDestroys[0], transform.position);
    }
    public void ReturnToPool()
    {
        ObjectPool.instance.Return(gameObject);
    }
    private void OnDisable()
    {
        GameEvent.returnLevel -= ReturnToPool;
    }
}