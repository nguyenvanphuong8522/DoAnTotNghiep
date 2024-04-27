using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int coin;
    public LevelScriptable dataLevel;
    public WaveManager waveManager;
    public Environment environment;

    public void InitLevel(int indexLevel, ListLevelScriptable data)
    {
        dataLevel = data.levels[indexLevel];
        SetEnvironmentData(data);
        SetUpWaveManager();
    }
    private void SetUpWaveManager()
    {
        waveManager.Init(dataLevel.waves);
        waveManager.NextWave();
    }
    private void SetEnvironmentData(ListLevelScriptable data)
    {
        EnvirInfor infor = new EnvirInfor()
        {
            listObstacle = dataLevel.listObstacle,
            home = data.homeSprites[dataLevel.homeSpriteIndex],
            bg = data.bgSprites[dataLevel.bgSpriteIndex],
            arr = dataLevel.waves.paths[0].path,
            posHouse = dataLevel.posHouse
        };
        environment.Init(infor);
    }
    public void EndLevel()
    {

    }
    public void SetCoin(int value, bool increase = true)
    {
        coin += increase ? value : -value;
    }
}
