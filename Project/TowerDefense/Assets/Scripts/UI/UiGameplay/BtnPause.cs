using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPause : MonoBehaviour
{
    [SerializeField] private ButtonEffectLogic btn;
    [SerializeField] private Sprite iconNormal;
    [SerializeField] private Sprite iconPressed;
    [SerializeField] private Image image;
    private GameState gameState;

    private void Awake()
    {
        btn.onClick.AddListener(PauseGame);
    }
    private void OnEnable()
    {
        GameEvent.returnLevel += UnPause;
    }
    private void Start()
    {
        gameState = GameState.instance;
    }
    private void PauseGame()
    {
        if (gameState.paused)
        {
            UnPause();
            return;
        }
        Pause();
    }

    private void Pause()
    {
        gameState.UpdateState(NameState.PAUSE);
        ChangeIcon(iconPressed);
    }
    private void UnPause()
    {
        gameState.UpdateState(NameState.UNPAUSE);
        ChangeIcon(iconNormal);
    }

    private void ChangeIcon(Sprite sprite)
    {
        image.sprite = sprite;
    }
    private void OnDisable()
    {
        GameEvent.returnLevel -= UnPause;
    }
}
