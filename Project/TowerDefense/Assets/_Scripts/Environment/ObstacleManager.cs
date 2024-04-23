using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private ObjectPool pool;

    private void Start() => pool = ObjectPool.instance;

    public void SpawnAObstacle(ObstacleScriptable data)
    {
        pool.Get(pool.obstacles[(int)data.name].pools[data.type], data.pos);
    }
    public void SpawnListObstacle(List<ObstacleScriptable> listObstacle)
    {
        foreach (var data in listObstacle)
        {
            SpawnAObstacle(data);
        }
    }
}
