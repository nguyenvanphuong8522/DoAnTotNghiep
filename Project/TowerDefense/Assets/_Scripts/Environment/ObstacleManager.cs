using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private ObjectPool pool;
    private List<ObstacleScriptable> listObstacle;

    private void Start()
    {
        pool = ObjectPool.instance;
    }
    public void SetListObstacle(int indexLevel)
    {
        listObstacle = LevelManager.instance.listLevel.levelList[indexLevel].listObstacle;
    }
    public void SpawnAObstacle(ObstacleScriptable data)
    {
        pool.Get(pool.obstacles[(int)data.name].pools[data.type], data.pos);
    }
    public void SpawnListObstacle()
    {
        foreach (var data in listObstacle)
        {
            SpawnAObstacle(data);
        }
    }
}
