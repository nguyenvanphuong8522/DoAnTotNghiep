using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

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

    public List<StrategyTower> tables;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        InitTables();
    }

    private void InitTables()
    {
        if (!PlayerPrefs.HasKey("TABLE"))
        {
            InitJsonTables();
            return;
        }
        tables = JsonToObj();
        Debug.Log(tables.Count);
    }
    private void InitJsonTables()
    {
        for (int i = 0; i < 5; i++)
        {
            int amountCol = tableData[i].list.Count;
            int amountCell = tableData[i].list[0].column.Length;
            tables.Add(new StrategyTower(amountCol, amountCell));
        }
        DataPersist.StringJsonTables = ObjToJson();
    }
    private List<StrategyTower> JsonToObj()
    {
        return JsonConvert.DeserializeObject<List<StrategyTower>>(DataPersist.StringJsonTables);
    }
    private string ObjToJson()
    {
        return JsonConvert.SerializeObject(tables);
    }
}
