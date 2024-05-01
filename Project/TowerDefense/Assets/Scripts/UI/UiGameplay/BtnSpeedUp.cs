using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSpeedUp : MonoBehaviour
{
    [SerializeField] private ButtonEffectLogic btn;
    [SerializeField] private Sprite iconNormal;
    [SerializeField] private Sprite iconPressed;
    [SerializeField] private Image image;
    private GameState gameState;

    private void Awake()
    {
        btn.onClick.AddListener(SpeedUp);
    }
    private void OnEnable()
    {
        GameEvent.returnLevel += NormalSpeed;
    }
    private void Start()
    {
        gameState = GameState.instance;
    }
    private void SpeedUp()
    {
        if (gameState.curTimeScale == 2)
        {
            NormalSpeed();
            return;
        }
        X2Speed();
    }
    private void NormalSpeed()
    {
        gameState.SetGameSpeed(1);
        ChangeIcon(iconNormal);
    }
    private void X2Speed()
    {
        gameState.SetGameSpeed(2);
        ChangeIcon(iconPressed);
    }

    private void ChangeIcon(Sprite sprite)
    {
        image.sprite = sprite;
    }
    private void OnDisable()
    {
        GameEvent.returnLevel -= NormalSpeed;
    }
}
