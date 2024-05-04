using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    private ListWaveScriptable listWaveData;

    private List<Path> paths;
    private Gate[] gates;
    public Wave curWave;
    private int waveIndex;
    public float timeDelayNextWave = 1.5f;
    private Coroutine coroutine;
    private int maxWave;
    private void OnEnable()
    {
        GameEvent.returnLevel += RestartWave;
    }
    public void RestartWave()
    {
        waveIndex = 0;
        StopCoroutineNextWave();
    }
    public void Init(ListWaveScriptable waves)
    {
        listWaveData = waves;
        InitGate();
        curWave = new Wave();
        paths = listWaveData.paths;
        maxWave = listWaveData.listWave.Count;
    }
    public void NextWave()
    {
        if (waveIndex < maxWave)
        {
            coroutine = StartCoroutine(DelayNextWave());
            return;
        }
        UiGameplay.instance.popupWin.Show();

    }
    private void StopCoroutineNextWave()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
    public void UpToDateWave()
    {
        WaveScriptable newWave = listWaveData.listWave[waveIndex];
        curWave.UpdateValue(gates, newWave);
        curWave.SetAmountEnemy();
        curWave.StartWave(paths);
        waveIndex++;
        UiGameplay.instance.UpdatTxtWave(waveIndex, maxWave);
    }

    private void InitGate()
    {
        int length = listWaveData.gatesPos.Length;
        gates = new Gate[length];
        for (int i = 0; i < length; i++)
        {
            GameObject newGate = ObjectPool.instance.Get(ObjectPool.instance.gate);
            newGate.SetActive(true);
            gates[i] = newGate.GetComponent<Gate>();
        }
    }
    private IEnumerator DelayNextWave()
    {
        yield return new WaitForSecondsRealtime(timeDelayNextWave);
        UpToDateWave();
    }

    private void OnDisable()
    {
        GameEvent.returnLevel -= RestartWave;
    }
}
