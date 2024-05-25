using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        UiGameplay.instance.btnPause.gameState = GameState.instance;
        StartCoroutine(DelayPause());
    }
    public override void EndStep()
    {
        Ground.instance.uiTowerUpgrade.SetPos(new Vector3(3.5f, -2.5f,0));
        Ground.instance.uiTowerUpgrade.Show();
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }
    private IEnumerator DelayPause()
    {
        yield return new WaitForSecondsRealtime(1);
        UiGameplay.instance.btnPause.PauseGame();
    }
}
