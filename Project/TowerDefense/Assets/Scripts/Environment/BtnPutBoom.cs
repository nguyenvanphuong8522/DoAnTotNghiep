using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPutBoom : MonoBehaviour
{
    public int timeUnlock;
    public ButtonEffectLogic btn;
    [SerializeField] private Image bg;
    [SerializeField] private Image icon;
    [SerializeField] private Image imgBtn;

    public void Lock()
    {
        imgBtn.raycastTarget = false;
        bg.color = new Color(0.4f, 0.4f, 0.4f, 1);
        icon.color = new Color(0.4f, 0.4f, 0.4f, 1);
    }
    public void Unlock()
    {
        imgBtn.raycastTarget = true;
        bg.color = Color.white;
        icon.color = Color.white;
    }
}
