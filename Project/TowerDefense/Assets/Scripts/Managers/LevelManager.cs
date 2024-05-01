using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public ListLevelScriptable listLevelData;
    public Level curLevel;
    private int indexLevel;

    [Button]
    public void Test()
    {
        InitLevel(1);
    }
    public void InitLevel(int index)
    {
        indexLevel = index;
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
