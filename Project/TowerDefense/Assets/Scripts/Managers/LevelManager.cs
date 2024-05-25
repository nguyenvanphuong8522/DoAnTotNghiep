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
        CameraController.instance.transform.position = listLevelData.levels[indexLevel].posCamera;
        curLevel.InitLevel(index, listLevelData);
        if (index == 0 && DataPersist.Tutorialed == 0)
        {
            GameTutorial.instance.StartTutorial();
        }
        
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
