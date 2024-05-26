using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWin : BasePopup
{
    public Button btnOk;
    public Text txtCompleted;
    public Text txtBonus;
    public Text txtResult;
    public StarWin starWin;
    private void Start()
    {
        btnOk.onClick.AddListener(Ok);
    }
    public void Ok()
    {
        LevelManager.instance.RemoveOldLevel();
        Uihome.instance.ShowHome();
        Loading.instance.Show();
        Hide();
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        LevelScriptable dataLevel = LevelManager.instance.listLevelData.levels[LevelManager.instance.indexLevel];
        UpdateText(dataLevel.coinCompleted, dataLevel.coinBonus * LevelManager.instance.curLevel.health);
        GameState.instance.UpdateState(NameState.PAUSE);
        starWin.Show(LevelManager.instance.curLevel.health);
        DataPersist.Level++;
        Uihome.instance.popUpManager.popUpLevel.Show();
    }
    private void UpdateText(int completed, int bonus)
    {
        txtCompleted.text = completed.ToString();
        txtBonus.text = bonus.ToString();
        int result = completed + bonus;
        txtResult.text = "+$ " + result;
        DataPersist.Money += result;
    }
}
