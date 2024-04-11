using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Grid grid;
    public Camera cam;
    public UiBuildTower uiBuildTower;
    private void OnMouseUp()
    {
        Show();
    }
    private void Show()
    {
        if(!Utils.IsPointerOverUIElement())
        {
            uiBuildTower.SetPos(GetPosToBuild());
            uiBuildTower.SetShowHide();
        }
    }
    public Vector3 GetPosToBuild()
    {
        Vector3 posToBuild = grid.WorldToCell(GetMousePos());
        posToBuild += Vector3.one * 0.5f;
        return posToBuild;
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
}
