using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    //Data
    private ListWaveScriptable listWaveData;

    private List<Path> paths;
    private Gate[] gates;
    public Wave curWave;
    private int waveIndex;
    private float timeDelayNextWave = 1.5f;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        listWaveData = LevelManager.instance.levelsData.levelList[0].waves;
        InitGate();
        curWave = new Wave();
        paths = listWaveData.paths;
    }
    public void NextWave()
    {
        StartCoroutine(DelayNextWave());
    }

    [Button]
    public void UpToDateWave()
    {
        WaveScriptable newWave = listWaveData.listWave[waveIndex];
        curWave.UpdateValue(gates, newWave);
        curWave.SetAmountEnemy();
        curWave.StartWave(paths);
        waveIndex++;
    }

    private void InitGate()
    {
        int length = listWaveData.gatesPos.Length;
        gates = new Gate[length];
        for(int i = 0; i < length; i++)
        {
            GameObject newGate = ObjectPool.instance.Get(ObjectPool.instance.gate);
            gates[i] = newGate.GetComponent<Gate>();
        }
    }
    private IEnumerator DelayNextWave()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        UpToDateWave();
    }
}
