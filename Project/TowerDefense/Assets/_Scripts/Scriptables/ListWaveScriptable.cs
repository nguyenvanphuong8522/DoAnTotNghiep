using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "Data/Waves")]
public class ListWaveScriptable : ScriptableObject
{
    public Vector3[] gatesPos;
    public List<Path> paths;
    public List<ArrayGate> listArrayGate;
}
[Serializable]
public class ArrayGate
{
    public GateScriptable[] gates;
}

[Serializable]
public class Path
{
    public Vector2[] path;
}

[Serializable]
public class GateScriptable
{
    public int amount;
    public float rate;
    public int type;
}
