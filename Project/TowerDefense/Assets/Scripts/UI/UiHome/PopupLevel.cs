using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupLevel : BasePopup
{
    [SerializeField] private List<BtnLevel> btnLevels;
    [SerializeField] private ButtonEffectLogic btnUpgrade;
    public Transform listBtn;
    
    private void Start()
    {
        btnUpgrade.onClick.AddListener(ShowPopupUpgarde);
    }
    [Button]
    public void GetBtnList()
    {
        foreach(Transform btnLevel in listBtn)
        {
            btnLevels.Add(btnLevel.GetComponent<BtnLevel>());
        }
    }
    [Button]
    public void SetName()
    {
        foreach (var btnLevel in btnLevels)
        {
            btnLevel.SetData(btnLevels.IndexOf(btnLevel));
            int lv = btnLevels.IndexOf(btnLevel);
            btnLevel.name = "btnLv" + lv;
            btnLevel.transform.GetChild(1).GetComponent<Text>().text = $"{++lv}";
        }
    }
    private void ShowPopupUpgarde()
    {
        Uihome.instance.popUpManager.popupUpgrade.Show();
    }
}
