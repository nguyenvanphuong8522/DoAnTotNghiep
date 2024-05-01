using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopupLevel : BasePopup
{
    [SerializeField] private List<BtnLevel> btnLevels;
    [SerializeField] private ButtonEffectLogic btnUpgrade;
    
    private void Start()
    {
        SetDataBtnLevels();
        btnUpgrade.onClick.AddListener(ShowPopupUpgarde);
    }
    private void SetDataBtnLevels()
    {
        foreach (var btnLevel in btnLevels)
        {
            btnLevel.SetData(btnLevels.IndexOf(btnLevel));
        }
    }

    private void ShowPopupUpgarde()
    {
        Uihome.instance.popUpManager.popupUpgrade.Show();
    }
}
