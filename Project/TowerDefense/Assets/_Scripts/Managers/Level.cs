using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int coin;
    public WaveManager waveManager;
    public Environment environment;
    
    private LevelScriptable dataCurLevel;
    private LevelManager lvManager;
    
    public void InitLevel()
    {
        environment.Init();
    }
    public void EndLevel()
    {

    }
    public void SetCoin(int value, bool increase = true)
    {
        coin += increase ? value : -value;
    }
}
