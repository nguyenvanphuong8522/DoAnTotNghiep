using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        box.enabled = false;
        StartCoroutine(CheckEnoughMoney());
    }
    public override void EndStep()
    {
        UiTowerUpgrade.instance.UpDateUi(transform.position, Vector3.one * 3.5f);
        UiTowerUpgrade.instance.UpdatePrice(100, 75);
        UiTowerUpgrade.instance.Show();
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }

    private IEnumerator CheckEnoughMoney()
    {
        while(true)
        {
            if(LevelManager.instance.curLevel.money >= 100)
            {
                UiGameplay.instance.btnPause.PauseGame();
                gameTutorial.dialogTalk.MoveCharacter(-72, 0.75f, true);
                gameTutorial.dialogTalk.ShowDialog(1);
                gameTutorial.dialogTalk.ShowCharacter();
                gameTutorial.hand.SetPosHand(posHand);
                gameTutorial.hand.Show();
                box.enabled = true;
                StopAllCoroutines();
                yield break;
            }
            yield return new WaitForSecondsRealtime(0.5f);
        } 
    }
}
