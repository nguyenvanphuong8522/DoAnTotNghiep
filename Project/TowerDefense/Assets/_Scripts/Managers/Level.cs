using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int coin;
    public WaveManager waveManager;
    public Environment environment;
    public ObstacleManager obstacleManager;
    public void StartLevel()
    {

    }

    public void EndLevel()
    {

    }
    public void SetCoin(int value, bool increase = true)
    {
        coin += increase ? value : -value;
    }
}
