using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<Transform> listEnemy = new List<Transform>();
    public Gun gun;

    //Add an enemy to the queue and start attack
    private void AddEnemy(Transform enemy)
    {
        listEnemy.Add(enemy);
        if(listEnemy.Count == 1) 
        {
            SetTargetGun();
        }
        StartAttack();
    }
    public void StartAttack()
    {
        if (!gun.isShootingObstacle && !gun.isAttacking)
        {
            gun.StartShoot();
        }
    }
    private void RemoveEnemy(Transform enemy)
    {
        listEnemy.Remove(enemy);
        if(enemy == gun.target)
        {
            CheckRemoveEnemy();
        }
    }
    public void CheckRemoveEnemy() 
    {
        if (gun.isShootingObstacle) return;

        if (listEnemy.Count > 0)
        {
            SetTargetGun();
            return;
        }
        gun.StopShoot();
    }

    //Update the target if not shooting an obstacle
    private void SetTargetGun()
    {
        if (!gun.isShootingObstacle)
        {
            gun.target = listEnemy[0];
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
    //Update enemyqueue when an enemy enters or exits trigger
    private void UpdateEnemyQueue(Collider2D enemy, bool add = true)
    {
        if (!enemy.CompareTag("Enemy")) return;
        if (add)
        {
            AddEnemy(enemy.transform);
            return;
        }
        RemoveEnemy(enemy.transform);
    }
    //Shoot or Stop shoot an obstacle
    public void ShootObstacle(Transform newTarget, bool value = true)
    {
        gun.StartPinTarget();
        if (value)
        {
            gun.target = newTarget;
            gun.StartShoot();
            return;
        }
        if (listEnemy.Count > 0)
        {
            SetTargetGun();
            gun.StartShoot();
        }
    }
}
