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
        if (!Utils.IsPointerOverUIElement())
        {
            popUp.SetPos(ConvertToGridPos.instance.GetPosToBuild());
            popUp.Show();
        }
    }

    public void ActionBtnTeleport()
    {
        powerUps[0].SetPos(popUp.transform.position);  
        powerUps[0].TurnOn();
        popUp.Hide();
    }
    public void ActionBtnBoom()
    {
        powerUps[1].SetPos(popUp.transform.position);
        powerUps[1].TurnOn();
        popUp.Hide();
    }

}
