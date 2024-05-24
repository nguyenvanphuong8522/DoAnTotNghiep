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
        if(dataLevel.bgSpriteIndex == 2)
        {
            environment.SetEffect(true);
        }
        else
        {
            environment.SetEffect();
        }
        health = 10;
        Vector2 size = new Vector2(14.4f, 10 + data.levels[indexLevel].heightBound);
        Vector2 offset = new Vector2(0,-1 - (data.levels[indexLevel].heightBound / 2));
        CameraController.instance.box.size = size;
        CameraController.instance.box.offset = offset;
        CameraController.instance.UpdataContraint();
        UiGameplay.instance.UpdatTxtHealth(health);
        Ground.instance.uiTowerUpgrade.Lock(data.levels[indexLevel].contraintTower);
        money = dataLevel.initMoney;
        UiGameplay.instance.UpdatTxtMoney();


        SetEnvironmentData(data);
        StartCoroutine(SetUpWaveManager());
        UiGameplay.instance.UpdatTxtWave(1, dataLevel.waves.listWave.Count);
        GameEvent.CallStartLevel();
    }
    private IEnumerator SetUpWaveManager()
    {
        yield return new WaitForSeconds(3);
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
            arr = dataLevel.waves.paths,
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
            StartCoroutine(DelayShowPopUpLose());
        }
    }
    private IEnumerator DelayShowPopUpLose()
    {
        yield return new WaitForSeconds(1.5f);
        UiGameplay.instance.popupLose.Show();
    }
}
