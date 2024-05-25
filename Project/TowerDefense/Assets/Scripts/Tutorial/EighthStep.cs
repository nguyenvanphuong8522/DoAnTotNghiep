using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EighthStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        gameTutorial.hand.SetBound(posHand);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameTutorial.dialogTalk.ShowDialog(0);
            gameTutorial.hand.Show();
            box.enabled = true;
            UiGameplay.instance.btnPause.Pause();
            transform.position = new Vector3(2.5f, -2.5f, -5);
        }
    }
    public override void EndStep()
    {
        gameTutorial.hand.Hide();
        UiGameplay.instance.btnPause.UnPause();
        gameTutorial.obstacle.CheckStartShootObstacles();
        gameTutorial.dialogTalk.Hide();
        gameTutorial.NextStep();
        gameObject.SetActive(false);
    }
}
