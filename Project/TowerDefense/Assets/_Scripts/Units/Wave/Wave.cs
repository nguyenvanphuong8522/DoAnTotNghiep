using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Wave
{
    public Gate[] gates;
    public void StartWave(Vector2[] paths)
    {
        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].StartSpawn(paths);
        }
    }
}
