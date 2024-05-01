using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Data/Levels")]
public class ListLevelScriptable : ScriptableObject
{
    public List<LevelScriptable> levels;
    public Sprite[] homeSprites;
    public Sprite[] bgSprites;
    public RuleTile[] rules;
}

[Serializable]
public class LevelScriptable
{
    public Vector3 posHouse;
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