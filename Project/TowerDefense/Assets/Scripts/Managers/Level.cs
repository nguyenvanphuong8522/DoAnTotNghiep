using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int health;
    public int money;
    public LevelScriptable dataLevel;
    public WaveManager waveManager;
    public Environment environment;

    public void InitLevel(int indexLevel, ListLevelScriptable data)
    {
        dataLevel = data.levels[indexLevel];
        health = 10;
        UiGameplay.instance.UpdatTxtHealth(health);
        IncreaseCoin(dataLevel.initMoney);
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
    public void IncreaseCoin(int value, bool increase = true)
    {
        money += increase ? value : -value;
        UiGameplay.instance.UpdatTxtMoney();
    }
    public void ReduceHeal()
    {
        UiGameplay.instance.UpdatTxtHealth(--health);
        if(health == 0)
        {
            UiGameplay.instance.popupLose.Show();
        }
    }
}
