using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;
    [Header("Reference")]
    public Table table;
    public Board board;
    //Data
    [Header("Icons")]
    public IconsCellScriptable iconsCellData;
    //Describe
    [Header("Describe")]
    public DescTowersScriptable descStrategyData;
    public DescTowersScriptable descAbilityData;
    public DescTowersScriptable descUpgradeData;
    public List<DescTowersScriptable> descTowersData;
    public List<DescTowersScriptable> descAbilitiesData;
    [Header("Price")]
    public List<Prices> pricesTower;
    public List<PriceScriptable> priceAbilities;

    public List<TableScriptable> towerTableData;
    public List<TableScriptable> abilityTableData;


    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    private void Start()
    {
        table.UpdateTable(0, towerTableData[0]);
    }
}
