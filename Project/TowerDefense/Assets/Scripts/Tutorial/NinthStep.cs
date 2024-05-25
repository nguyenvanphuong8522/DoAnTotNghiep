using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinthStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        StartCoroutine(CheckNewWave());
    }
    public override void EndStep() {}
    private IEnumerator CheckNewWave()
    {
        while (true)
        {
            if (LevelManager.instance.curLevel.waveManager.waveIndex == 5)
            {
                UiGameplay.instance.btnPause.PauseGame();
                gameTutorial.dialogTalk.MoveCharacter(-72, 0.75f, true);
                gameTutorial.dialogTalk.ShowDialog(0);
                gameTutorial.dialogTalk.ShowCharacter();
                gameTutorial.btnEnd.gameObject.SetActive(true);
                StopAllCoroutines();
                yield break;
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
