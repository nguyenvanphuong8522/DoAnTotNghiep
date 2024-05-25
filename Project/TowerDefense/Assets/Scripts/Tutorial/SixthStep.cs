using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        gameTutorial.hand.SetBound(posHand);
    }
    public override void EndStep()
    {
        PowerUpPopUp.instance.btnTeleport.Unlock();
        PowerUpPopUp.instance.btnTeleport.btn.onClick.Invoke();
        gameTutorial.hand.Hide();
        UiGameplay.instance.btnPause.UnPause();
        gameTutorial.dialogTalk.Hide();
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }

}
