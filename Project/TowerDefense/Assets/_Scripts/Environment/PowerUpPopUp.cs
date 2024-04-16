using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerUpPopUp : BasePopup
{
    public Button btnBoom, btnTeleport;
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }
    public void SetListenBtns(UnityAction action1, UnityAction action2)
    {
        btnTeleport.onClick.AddListener(action1);
        btnBoom.onClick.AddListener(action2);
    }
}
