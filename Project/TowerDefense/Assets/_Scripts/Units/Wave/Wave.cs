using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    private Gate[] gates;

    private int amountEnemy;
    public void StartWave(List<Path> paths)
    {
        for (int i = 0; i < gates.Length; i++)
        {
            gates[i].StartSpawn(paths[i]);
        }
    }
    public void ReduceCountEnemy()
    {
        amountEnemy--;
        if(amountEnemy <= 0)
        {
            EndWave();
        }
    }
    public void SetAmountEnemy()
    {
        foreach (Gate gate in gates)
        {
            amountEnemy += gate.amount;
        }
    }
    public void EndWave()
    {
        WaveManager.instance.NextWave();
    }
    public void UpdateValue(Gate[] gates, WaveScriptable wave)
    {
        this.gates = gates;
        SetValueGates(wave);
    }
    public void SetValueGates(WaveScriptable wave)
    {
        for (int i = 0; i < gates.Length; i++)
        {
            GateScriptable gateValue = wave.gates[i];
            gates[i].SetValueGate(gateValue);
        }
    }
    public bool waveIsCleared() => amountEnemy <= 0 ? true: false;

}
