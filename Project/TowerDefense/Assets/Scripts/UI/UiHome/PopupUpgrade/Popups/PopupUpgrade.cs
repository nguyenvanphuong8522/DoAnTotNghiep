using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;
    public Table table;
    public Board board;
    //Data
    public List<TableScriptable> tableData;
    public InforTowersScriptable inforTowersData;
    public IconsCellScriptable iconsCellData;
    public List<InforTowersScriptable> childrenInforTowerData;
    public InforTowersScriptable inforUpgradeTypeData;
    public List<InforTowersScriptable> inforAbilitiesData;


    protected override void Awake()
    {
        base.Awake();   
        instance = this;
    }

}
