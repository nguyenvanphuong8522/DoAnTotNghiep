using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        gameTutorial.hand.SetBound(posHand);
        box.enabled = false;
        StartCoroutine(CheckNewWave());
    }
    public override void EndStep()
    {
        gameTutorial.hand.Hide();
        UiGameplay.instance.btnPause.UnPause();
        gameTutorial.dialogTalk.HideDialog();
        gameTutorial.obstacle.CheckStartShootObstacles();
        Arrow.instance.SetPos(gameTutorial.obstacle.transform.position);
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }
    private IEnumerator CheckNewWave()
    {
        while (true)
        {
            if (LevelManager.instance.curLevel.waveManager.waveIndex == 4)
            {
                UiGameplay.instance.btnPause.PauseGame();
                gameTutorial.dialogTalk.MoveCharacter(-72, 0.75f, true);
                gameTutorial.dialogTalk.ShowDialog(1);
                gameTutorial.dialogTalk.ShowCharacter();
                gameTutorial.hand.Show();
                box.enabled = true;
                StopAllCoroutines();
                yield break;
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
