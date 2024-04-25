using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToGridPos : Singleton<ConvertToGridPos>
{
    public Grid grid;
    public Camera cam;
   
    public Vector3 GetPosToBuild()
    {
        Vector3 posToBuild = grid.WorldToCell(GetMousePos());
        posToBuild += Vector3.one * 0.5f;
        posToBuild.z = -1;
        return posToBuild;
    }
    public Vector3 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
}
