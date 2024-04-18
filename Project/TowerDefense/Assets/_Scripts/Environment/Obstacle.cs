using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health;
    public Animator animator;
    public List<TowerAttack> towerAttacks;
    public bool isUnderAttack = false;
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
    public void ReturnToPool()
    {
        ObjectPool.instance.Return(gameObject);
    }
    private void SetDie()
    {
        CheckStartShootObstacles();
        SpawnEffectDie();
        ReturnToPool();
    }
    private void SpawnEffectDie()
    {
        GameObject die = ObjectPool.instance.Get(ObjectPool.instance.obstacleDestroys[0], transform.position);
    }
}
