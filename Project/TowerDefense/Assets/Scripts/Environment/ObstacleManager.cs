using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private ObjectPool pool;

    private void Start() => pool = ObjectPool.instance;

    public void SpawnAObstacle(ObstacleScriptable data)
    {
        Vector3 newPos = data.pos;
        newPos.z = -1;
        pool.Get(pool.obstacles[(int)data.name].pools[data.type], newPos);
    }
    public void SpawnListObstacle(List<ObstacleScriptable> listObstacle)
    {
        foreach (var data in listObstacle)
        {
            SpawnAObstacle(data);
        }
    }
}
