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
        UpdateTargetInQueue();
        StartAttack();
    }
    public void StartAttack()
    {
        if (!gun.isShootingObstacle)
        {
            gun.StartShoot();
        }
    }
    private void RemoveEnemy()
    {
        queueEnemies.Dequeue();
        CheckRemoveEnemy();
    }
    public void CheckRemoveEnemy()
    {
        if (!gun.isShootingObstacle)
        {
            if (queueEnemies.Count > 0)
            {
                UpdateTargetInQueue();
                return;
            }
            gun.StopShoot();
        }
    }
    private void UpdateTargetInQueue()
    {
        if (!gun.isShootingObstacle)
        {
            gun.target = queueEnemies.Peek();
        }
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
                return;
            }
            RemoveEnemy();
        }
    }
    public void ShootObstacle(Transform newTarget, bool value = true)
    {
        gun.StartPinTarget();
        if(value)
        {
            gun.target = newTarget;
            gun.StartShoot();
            return;
        }
        if (queueEnemies.Count > 0)
        {
            UpdateTargetInQueue();
            gun.StartShoot();
        }
    }
    //public void StartShootObstacle(Transform newTarget)
    //{
    //    gun.StartPinTarget();

    //    gun.target = newTarget;
    //    gun.StartShoot();
    //}
    //public void StopShootObstacle()
    //{
    //    gun.StartPinTarget();

    //    if (queueEnemies.Count > 0)
    //    {
    //        UpdateTargetInQueue();
    //        gun.StartShoot();
    //    }
    //}
}
