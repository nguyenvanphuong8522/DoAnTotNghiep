using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public ListLevelScriptable listLevel;
    public Level curLevel;
    public int curIndex;
    private void Start()
    {
        curLevel.InitLevel();
    }
}
