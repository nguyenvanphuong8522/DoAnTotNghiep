using System;
using System.Collections.Generic;
using UnityEngine;

public class UiBuildTower : MonoBehaviour
{
    public bool isShowing = false;
    public Transform indicator;
    public Transform canvas;
    public void SetShowHide()
    {
        isShowing = !isShowing;
        SetActiveUiBuilder(isShowing);
    }
    public void SetActiveUiBuilder(bool value)
    {
        indicator.gameObject.SetActive(value);
        canvas.gameObject.SetActive(value);
        isShowing = value;
    }
    public void SetPos(Vector3 pos)
    {
        indicator.position = canvas.position = pos;
    }
}
