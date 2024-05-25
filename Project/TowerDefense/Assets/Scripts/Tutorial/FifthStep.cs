using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        gameTutorial.hand.SetBound(posHand);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameTutorial.dialogTalk.MoveCharacter(-72, 0.75f, true);
            gameTutorial.dialogTalk.ShowDialog(1);
            gameTutorial.dialogTalk.ShowCharacter();
            gameTutorial.hand.Show();
            UiGameplay.instance.btnPause.Pause();
            transform.position = new Vector3(4.5f, -0.5f, -5);
            box.offset = Vector3.zero;
        }
    }
    public override void EndStep()
    {
        PowerUpPopUp.instance.SetPos(transform.position);
        PowerUpPopUp.instance.Show();
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }
}
