using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public ListLevelScriptable listLevelData;
    public Level curLevel;
    public int indexLevel;

    [Button]
    public void Test()
    {
        InitLevel(1);
    }
    public void InitLevel(int index)
    {
        indexLevel = index;
        CameraController.instance.transform.position = new Vector3(0, 0, -10);
        curLevel.InitLevel(index, listLevelData);
    }
    [Button]
    public void RestartLevel()
    {
        RemoveOldLevel();
        InitLevel(indexLevel);
    }

    public void RemoveOldLevel()
    {
        GameEvent.CallReturnLevel();
        ObjectPool.instance.ReturnAllPool();
    }
}
