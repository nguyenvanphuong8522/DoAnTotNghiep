using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Data/Levels")]
public class LevelsScriptable : ScriptableObject
{
    public List<LevelScriptable> levelList;
}

[Serializable]
public class LevelScriptable
{
    public ListWaveScriptable waves;
}
