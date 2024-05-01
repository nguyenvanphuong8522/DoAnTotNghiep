using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLevel : MonoBehaviour
{
    [SerializeField] private ButtonEffectLogic btn;
    [SerializeField] private int lv;

    private void Start()
    {
        btn.onClick.AddListener(EventClick);
    }
    public void SetData(int lv)
    {
        this.lv = lv;   
    }

    public void EventClick()
    {
        Uihome.instance.HideHome();
        Uihome.instance.popUpManager.popUpLevel.Hide();
        LevelManager.instance.InitLevel(lv);
    }
}
