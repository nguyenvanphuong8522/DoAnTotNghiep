using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerUpPopUp : BasePopup
{
    public static PowerUpPopUp instance;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
        Hide();
    }
    public BtnPutBoom btnBoom, btnTeleport;
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
    public void SetListenBtns(UnityAction action1, UnityAction action2)
    {
        btnTeleport.btn.onClick.AddListener(action1);
        btnBoom.btn.onClick.AddListener(action2);
    }
}
