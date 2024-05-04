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
        GameState.instance.UpdateState(NameState.PAUSE);
    }
}
