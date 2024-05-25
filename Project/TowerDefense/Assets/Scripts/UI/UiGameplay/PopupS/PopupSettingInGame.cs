using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSettingInGame : BasePopup
{
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnExit;
    protected override void Awake()
    {
        base.Awake();
        Hide();
    }
    private void Start()
    {
        btnResume.onClick.AddListener(Resume);
        btnRestart.onClick.AddListener(Restart);
        btnExit.onClick.AddListener(Exit);
    }
    public void Restart()
    {
        Hide();
        LevelManager.instance.RestartLevel();
    }
    private void Resume()
    {
        if(!UiGameplay.instance.btnSetting.isPausedAfter)
        {
            GameState.instance.UpdateState(NameState.UNPAUSE);
        }
        Hide();
    }
    private void Exit()
    {
        LevelManager.instance.RemoveOldLevel();
        Uihome.instance.ShowHome();
        Hide();
    }
}
