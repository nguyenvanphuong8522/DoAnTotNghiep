using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    private Queue<Transform> queueEnemies = new Queue<Transform>();
    private void AddEnemyIntoQueue(Transform enemy)
    {
        Debug.LogError("add new enemy");
    }
    private Transform GetEnemy()
    {
        return null;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            AddEnemyIntoQueue(col.transform);
        }
    }
}
