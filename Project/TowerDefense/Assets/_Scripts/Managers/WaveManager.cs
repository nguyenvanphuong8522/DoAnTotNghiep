using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public List<Vector2[]> paths;
    public Gate[] gates;
    private Wave curWave;
    

    private void Start()
    {
        ListWaveScriptable listWave = LevelManager.instance.levelsData.levelList[0].waves;
        curWave = new Wave();
        curWave.gates = gates;
        curWave.StartWave(listWave.paths[0].path);
    }

    
}
