using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondStep : BaseStep
{
    public override void EndStep()
    {
        Ground.instance.uiTowerUpgrade.Hide();
        LevelManager.instance.curLevel.money -= 100;
        UiGameplay.instance.UpdatTxtMoney();
        SpawnTower();
        gameTutorial.hand.Hide();
        UiGameplay.instance.btnPause.PauseGame();
        gameTutorial.dialogTalk.Hide();
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }

    private void SpawnTower()
    {
        gameTutorial.tower = ObjectPool.instance.Get(ObjectPool.instance.towers[0].pools[0], new Vector3(3.5f, -2.5f, 0));
    }
}
