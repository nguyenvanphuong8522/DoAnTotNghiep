using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Road : MonoBehaviour
{
    public PowerUpPopUp popUp;
    public PowerUp[] powerUps;
    private Vector3 preClick;
    [SerializeField] private IconAbility iconTele;
    [SerializeField] private IconAbility iconBoom;
    private void Awake()
    {
        popUp.SetListenBtns(ActionBtnTeleport, ActionBtnBoom);
    }
    private void OnMouseDown()
    {
        preClick = ConvertToGridPos.instance.GetMousePos();
    }
    private void OnMouseUp()
    {
        Vector3 curClick = ConvertToGridPos.instance.GetMousePos();
        float distance = Vector3.Distance(curClick, preClick);

        if (!Utils.IsPointerOverUIElement() && distance < 0.00001f)
        {
            popUp.SetPos(ConvertToGridPos.instance.GetPosToBuild());
            popUp.Show();
        }
    }

    public void ActionBtnTeleport()
    {
        iconTele.Lock();
        powerUps[0].SetPos(popUp.transform.position);  
        powerUps[0].TurnOn();
        //StartCoroutine(DelayTeleUnlock());
        popUp.Hide();
    }
    public void ActionBtnBoom()
    {
        iconBoom.Lock();
        powerUps[1].SetPos(popUp.transform.position);
        powerUps[1].TurnOn();
        //StartCoroutine(DelayBoomUnlock());
        popUp.Hide();
    }
    

    private IEnumerator DelayTeleUnlock()
    {
        yield return new WaitForSeconds(popUp.btnTeleport.timeUnlock);
        popUp.btnTeleport.Unlock();
    }
    private IEnumerator DelayBoomUnlock()
    {
        yield return new WaitForSeconds(popUp.btnBoom.timeUnlock);
        popUp.btnBoom.Unlock();
    }
}
