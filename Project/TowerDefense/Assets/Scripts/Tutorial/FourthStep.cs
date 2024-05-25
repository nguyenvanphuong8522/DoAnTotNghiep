using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FourthStep : BaseStep
{
    public override void StartStep()
    {
        base.StartStep();
        UiGameplay.instance.btnPause.Pause();
    }
    public override void EndStep()
    {
        UiTowerUpgrade.instance.Hide();
        gameTutorial.hand.Hide();
        gameTutorial.dialogTalk.Hide();
        gameTutorial.NextStep();
        ObjectPool.instance.Return(gameTutorial.tower);
        gameTutorial.obstacle = ObjectPool.instance.transform.GetChild(34).GetComponent<Obstacle>();
        gameTutorial.obstacle.towerAttacks.Clear();
        gameTutorial.tower = ObjectPool.instance.Get(ObjectPool.instance.towers[0].pools[1], new Vector3(3.5f, -2.5f, 0));
        UiGameplay.instance.btnPause.UnPause();
        gameObject.SetActive(false);
    }

}
