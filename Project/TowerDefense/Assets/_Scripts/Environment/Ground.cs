using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Singleton<Ground>
{
    public UiBuildTower uiTowerUpgrade;
    private void OnMouseUp()
    {
        if (!Utils.IsPointerOverUIElement())
        {
            uiTowerUpgrade.SetPos(ConvertToGridPos.instance.GetPosToBuild());
            uiTowerUpgrade.Show();
        }
    }
}
