using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int amount;
    private float rate;
    private int type;
    public void StartSpawn(Path path)
    {
        StartCoroutine(SpawnEnemy(path));
    }
    private IEnumerator SpawnEnemy(Path path)
    {
        while(amount > 0)
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
        amount = gateData.amount;
        type = gateData.type;
        rate = gateData.rate;
    }
}
