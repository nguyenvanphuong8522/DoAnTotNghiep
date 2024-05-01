using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : MonoBehaviour
{
    [SerializeField] private ButtonEffectLogic btn;
    private GameState gameState;
    public bool isPausedAfter = false;

    private void Awake()
    {
        btn.onClick.AddListener(OpenSetting);
    }
    private void Start()
    {
        gameState = GameState.instance;
    }
    private void OpenSetting()
    {
        UiGameplay.instance.popUpSetting.Show();
        if (gameState.paused)
        {
            isPausedAfter = true;
            return;
        }

        gameState.UpdateState(NameState.PAUSE);
    }

}
