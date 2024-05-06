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

    public List<DataTable> tables;

    protected override void Awake()
    {
        base.Awake();   
        instance = this;
        if(!PlayerPrefs.HasKey("TABLE"))
        {
            Debug.Log("null");
            InitJsonTables();
        }
        else
        {
            tables = JsonUtility.FromJson<List<DataTable>>(DataPersist.StringJsonTables);
            Debug.Log(tables.Count);
            Debug.Log(DataPersist.StringJsonTables);
        }
    }

    private void InitJsonTables()
    {
        for (int i = 0; i < 5; i++)
        {
            DataTable dataTable = new DataTable();
            dataTable.list = new DataColumn[3];
            tables.Add(dataTable);
        }
    }


}
