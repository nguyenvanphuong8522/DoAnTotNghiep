using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : BasePopup
{
    public Button btnOk;
    private void Start()
    {
        btnOk.onClick.AddListener(Ok);
    }
    public void Ok()
    {
        LevelManager.instance.RemoveOldLevel();
        Uihome.instance.ShowHome();
        Hide();
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        LevelScriptable dataLevel = LevelManager.instance.listLevelData.levels[LevelManager.instance.indexLevel];
        DataPersist.Money += dataLevel.coinCompleted;
        DataPersist.Money += dataLevel.coinBonus * LevelManager.instance.curLevel.health;
        GameState.instance.UpdateState(NameState.PAUSE);
    }
}
