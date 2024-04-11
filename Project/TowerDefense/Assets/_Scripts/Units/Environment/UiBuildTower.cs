using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;

public class UiBuildTower : MonoBehaviour
{
    private bool isShowing = false;
    public Transform indicator;
    public Transform canvas;
    public void SetShowHide()
    {
        isShowing = !isShowing;
        SetActiveUiBuilder(isShowing);
    }
    private void SetActiveUiBuilder(bool value)
    {
        indicator.gameObject.SetActive(value);
        canvas.gameObject.SetActive(value);
    }
    public void SetPos(Vector3 pos)
    {
        indicator.position = canvas.position = pos;
    }
}
