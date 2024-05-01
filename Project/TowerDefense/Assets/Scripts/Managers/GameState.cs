using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameState : Singleton<GameState>
{
    private NameState curState;
    public bool paused = false;
    public int curTimeScale = 1;

    private void OnEnable()
    {
        UpdateState(NameState.MENU);
    }
    public void UpdateState(NameState state)
    {
        curState = state;
        switch (state)
        {
            case NameState.MENU:
                HandleMenuState();
                break;
            case NameState.PLAY:
                HandlePlayState();
                break;
            case NameState.PAUSE:
                Pause();
                break;
            case NameState.UNPAUSE:
                UnPause();
                break;
            default:
                break;
        }
    }

    private void HandlePlayState()
    {

    }
    private void HandleMenuState()
    {

    }
    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        paused = false;
        Time.timeScale = curTimeScale;
    }
    public void SetGameSpeed(int speed)
    {
        curTimeScale = speed;
        if (!paused)
        {
            Time.timeScale = curTimeScale;
        }
    }
}
