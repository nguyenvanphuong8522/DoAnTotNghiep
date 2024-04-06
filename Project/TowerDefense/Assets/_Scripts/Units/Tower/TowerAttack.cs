using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private Queue<Transform> queueEnemies = new Queue<Transform>();

    [Space(3)]
    [Header("References")]
    [SerializeField]private Gun gun;

    private void AddEnemy(Transform enemy)
    {
        queueEnemies.Enqueue(enemy);

        SetGunValue();

        gun.StartShoot();
    }
    private void RemoveEnemy()
    {
        queueEnemies.Dequeue();
        if(queueEnemies.Count > 0)
        {
            SetGunValue();
        }
        else
        {
            gun.StopShoot();
        }
    }
    private void SetGunValue() => gun.target = queueEnemies.Peek();

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
    #region Gizmos
    //private void OnDrawGizmos()
    //{
    //    if (curTarget != null)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawLine(transform.position, curTarget.position);
    //    }
    //}
    #endregion
}
