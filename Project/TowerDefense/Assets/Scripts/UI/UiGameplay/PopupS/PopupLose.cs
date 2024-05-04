using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupLose : BasePopup
{
    public Button btnQuit;
    public Button btnRestart;
    private void Start()
    {
        btnRestart.onClick.AddListener(Restart);
        btnQuit.onClick.AddListener(Quit);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        GameState.instance.UpdateState(NameState.PAUSE);
    }

    public void Restart()
    {
        Hide();
        LevelManager.instance.RestartLevel();
    }

    public void Quit()
    {
        LevelManager.instance.RemoveOldLevel();
        Uihome.instance.ShowHome();
        Hide();
    }
}
