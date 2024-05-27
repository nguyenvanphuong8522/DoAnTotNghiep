using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Singleton<Ground>
{
    public UiBuildTower uiTowerUpgrade;
    private Vector3 preClick;
    private void OnMouseDown()
    {
        preClick = ConvertToGridPos.instance.GetMousePos();
    }
    private void OnMouseUp()
    {
        Vector3 curClick = ConvertToGridPos.instance.GetMousePos();
        float distance = Vector3.Distance(curClick, preClick);

        if (!Utils.IsPointerOverUIElement() && distance <= 0.00001f)
        {
            if(ConvertToGridPos.instance.GetPosToBuild().y >= 3.4f)
            {
                uiTowerUpgrade.SetPos(ConvertToGridPos.instance.GetPosToBuild() - Vector3.up);
            }
            else
            {
                uiTowerUpgrade.SetPos(ConvertToGridPos.instance.GetPosToBuild());
            }
            uiTowerUpgrade.Show();
        }
    }
}
