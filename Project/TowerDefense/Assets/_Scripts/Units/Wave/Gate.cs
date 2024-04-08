using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Vector3 pos;
    public int count;
    public float rate;
    public int type;
    private Coroutine coroutine;

    public void StartSpawn(Vector2[] path)
    {
        StartCoroutine(SpawnEnemy(path));
    }
    private IEnumerator SpawnEnemy(Vector2[] path)
    {
        while(count > 0)
        {
            SingleSpawn(path);
            count--;
            yield return new WaitForSeconds(rate);
        }
    }
    private void SingleSpawn(Vector2[] path)
    {
        GameObject newEnemy = ObjectPool.instance.Get(ObjectPool.instance.enemyLives[type], pos);
        EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.SetPath(path);
        }
    }
}
