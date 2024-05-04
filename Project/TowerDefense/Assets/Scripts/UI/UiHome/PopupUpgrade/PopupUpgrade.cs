using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;

    public List<UpgradeBoardScriptable> upgradeBoardData;
    public ListIconBtnUpgradeScriptable listIconBtnUpgrade;
    public InforTowerUi inforTowerUi;
    public UpgradeBoard upgradeBoard;
    protected override void Awake()
    {
        base.Awake();   
        instance = this;
    }

}
