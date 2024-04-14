using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health;
    public Animator animator;
    public List<TowerAttack> towerAttacks;
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SetDie();
        }
    }
    private void OnMouseUp()
    {
        CheckStartShootObstacles();
    }
    public  void CheckStartShootObstacles()
    {
        foreach(TowerAttack element in towerAttacks)
        {
            CheckIsShootObstacle(element);
        }
    }
    public void CheckIsShootObstacle(TowerAttack towerAttack)
    {
        if (!towerAttack.gun.isShootingObstacle)
        {
            towerAttack.StartShootObstacle(transform);
        }
        else
        {
            towerAttack.StopShootObstacle();
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
        if(col.CompareTag("Tower")) {
            TowerAttack towerAttack = col.gameObject.GetComponentInParent<TowerAttack>();
            if(towerAttack != null)
            {
                towerAttacks.Add(towerAttack);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Tower")) {
            TowerAttack towerAttack = col.gameObject.GetComponentInParent<TowerAttack>();
            if(towerAttack != null)
            {
                towerAttacks.Remove(towerAttack);
            }
        }
    }

    public void ReturnToPool()
    {
        ObjectPool.instance.Return(gameObject);
    }
    private void SetDie()
    {
        SpawnEffectDie();
        ReturnToPool();
    }
    private void SpawnEffectDie()
    {
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.obstacleDestroys[0], transform.position);
    }
}
