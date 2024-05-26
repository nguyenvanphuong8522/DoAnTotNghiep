using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int amount;
    private float rate;
    private int type;
    private Coroutine coroutine;
    private void OnEnable()
    {
        GameEvent.returnLevel += StopSpawn;
    }
    public void StartSpawn(Path path)
    {
        StopSpawn();
        coroutine = StartCoroutine(SpawnEnemy(path));
    }
    private void StopSpawn()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
    private IEnumerator SpawnEnemy(Path path)
    {
        while (amount > 0)
        {
            SingleSpawn(path);
            amount--;
            yield return new WaitForSeconds(rate);
        }
    }
    private void SingleSpawn(Path path)
    {
        GameObject newEnemy = ObjectPool.instance.Get(ObjectPool.instance.enemyLives[type]);
        EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.SetPath(path);
            enemyMovement.Init();
        }
        newEnemy.SetActive(true);
    }
    public void SetValueGate(GateScriptable gateData)
    {
        StopSpawn();
        amount = gateData.amount;
        type = gateData.type;
        rate = gateData.rate;
    }
    private void OnDisable()
    {
        StopSpawn();
        GameEvent.returnLevel -= StopSpawn;
    }
}
