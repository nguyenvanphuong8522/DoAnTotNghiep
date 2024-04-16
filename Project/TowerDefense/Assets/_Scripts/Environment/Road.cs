using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public PowerUpPopUp popUp;
    public PowerUp[] powerUps;
    private void Awake()
    {
        popUp.SetListenBtns(ActionBtnTeleport, ActionBtnBoom);
    }
    private void OnMouseUp()
    {
        popUp.SetPos(ConvertToGridPos.instance.GetPosToBuild());
        popUp.Show();
    }
    public void ActionBtnTeleport()
    {
        powerUps[0].TurnOn();
    }
    public void ActionBtnBoom()
    {
        powerUps[1].TurnOn();
    }

}
