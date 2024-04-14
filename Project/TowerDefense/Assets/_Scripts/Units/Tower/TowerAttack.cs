using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private Queue<Transform> queueEnemies = new Queue<Transform>();
    public Gun gun;

    private void AddEnemy(Transform enemy)
    {
        queueEnemies.Enqueue(enemy);
        SetGunTarget();
        gun.CheckAndShoot();
    }
    private void RemoveEnemy()
    {
        queueEnemies.Dequeue();
        if(!gun.isShootingObstacle)
        {
            CheckRemoveEnemy();
        }
    }
    public void CheckRemoveEnemy()
    {
        if (queueEnemies.Count > 0)
        {
            SetGunTarget();
        }
        else
        {
            gun.StopShoot();
        }
    }
    private void SetGunTarget()
    {
        if(!gun.isShootingObstacle)
        {
            gun.target = queueEnemies.Peek();
        }
    }
    public void SetGunTarget(Transform target)
    {
        gun.target = target;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        UpdateEnemyQueue(col);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        UpdateEnemyQueue(col, false);
    }

    private void UpdateEnemyQueue(Collider2D enemy, bool add = true)
    {
        if (enemy.CompareTag("Enemy"))
        {
            if (add)
            {
                AddEnemy(enemy.transform);
            }
            else
            {
                RemoveEnemy();
            }
        }
    }
    public void StartShootObstacle(Transform newTarget)
    {
        gun.StopShoot();
        gun.isShootingObstacle = true;
        SetGunTarget(newTarget);
        gun.StartShoot();
    }

    public void StopShootObstacle()
    {
        gun.StopShoot();
        gun.isShootingObstacle = false;
        if (queueEnemies.Count > 0)
        {
            SetGunTarget();
            gun.StartShoot();
        }
    }
}
