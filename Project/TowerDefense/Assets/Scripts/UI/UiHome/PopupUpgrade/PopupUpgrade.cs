using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;
    public List<UpgradeBoardScriptable> upgradeBoard;
    public ListIconBtnUpgradeScriptable listIconBtnUpgrade;
    protected override void Awake()
    {
        base.Awake();   
        instance = this;
    }

}
