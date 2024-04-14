using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Singleton<Ground>
{
    public Grid grid;
    public Camera cam;
    public UiBuildTower uiBuildTower;
    private void OnMouseUp()
    {
        if(!Utils.IsPointerOverUIElement()) 
        {
            Show();
        }
    }
    private void Show()
    {
        if(UiTowerUpgrade.instance.isShowing)
        {
            UiTowerUpgrade.instance.SetActiveUiBuilder(false);
        }
        else
        {
            uiBuildTower.SetPos(GetPosToBuild());
            uiBuildTower.SetShowHide();
        }
        
    }
    public Vector3 GetPosToBuild()
    {
        Vector3 posToBuild = grid.WorldToCell(GetMousePos());
        posToBuild += Vector3.one * 0.5f;
        posToBuild.z = -1;
        return posToBuild;
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
}
