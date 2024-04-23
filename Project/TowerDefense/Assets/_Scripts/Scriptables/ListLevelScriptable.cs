using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Data/Levels")]
public class ListLevelScriptable : ScriptableObject
{
    public List<LevelScriptable> levelList;
    public Sprite[] homeSprites;
    public Sprite[] bgColors;
}

[Serializable]
public class LevelScriptable
{
    public int bgSpriteIndex;
    public int homeSpriteIndex;
    public ListWaveScriptable waves;
    public List<ObstacleScriptable> listObstacle;
}


[Serializable]
public class ObstacleScriptable
{
    public Vector3 pos;
    public NameObstacle name;
    public int type;
}


[Serializable]
public enum NameObstacle
{
    Tree,
    Rock,
    Brush
}
