using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public ListLevelScriptable listLevelData;
    public Level curLevel;


    [Button]
    public void Test()
    {
        InitLevel(0);
    }
    public void InitLevel(int index)
    {
        curLevel.InitLevel(index, listLevelData);
    }
}
