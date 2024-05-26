using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHangarSave : Singleton<DataHangarSave>
{
    [HideInInspector]public DataTablesSave tablesSave;
    public TableTower tableTower;
    protected override void Awake()
    {
        base.Awake();
        CheckInitData();
    }

    [Button]
    public void TestMoney()
    {
        DataPersist.Money += 1000;
        PopupUpgrade.instance.UpdateTxtMoney();
    }
    public void CheckInitData()
    {
        if (!PlayerPrefs.HasKey("TABLE"))
        {
            InitTableSave();
            Save();
            return;
        }
        Debug.Log("has key");
        tablesSave = GetOldData();
    }
    private void InitTableSave()
    {
        tablesSave = new DataTablesSave();
        for (int i = 0; i < tableTower.towerTableData.Count; i++)
        {
            TableSave tableSave = new TableSave();
            int length = tableTower.towerTableData[i].columns.Count;
            for (int j = 0; j < length; j++)
            {
                tableSave.AddColumn(GetUpgradeType(i, j));
            }
            tablesSave.AddTable(tableSave);
        }
        InitUnlock();
        InitPurchased();
    }
    private void InitUnlock()
    {
        for (int i = 0; i < 5; i++)
        {
            Unlock(i, 0);
        }
    }
    private void InitPurchased()
    {
        tablesSave.dataTablesSave[0].columnSaves[0].Purchase();
        tablesSave.dataTablesSave[0].columnSaves[0].types[0].UnLock();
        tablesSave.dataTablesSave[0].columnSaves[1].UnLock();
        tablesSave.dataTablesSave[0].columnSaves[1].Purchase();
        tablesSave.dataTablesSave[0].columnSaves[1].types[0].UnLock();
        tablesSave.dataTablesSave[0].columnSaves[2].UnLock();

        tablesSave.dataTablesSave[1].columnSaves[0].Purchase();
        tablesSave.dataTablesSave[1].columnSaves[1].UnLock();
        tablesSave.dataTablesSave[1].columnSaves[0].types[0].UnLock();
        Save();
    }
    private DataTablesSave GetOldData()
    {
        return JsonConvert.DeserializeObject<DataTablesSave>(DataPersist.JsonTables);
    }
    public List<UpgradeSave> GetUpgradeType(int indexTower, int indexColumn)
    {
        UpgradeType[] data = tableTower.towerTableData[indexTower].columns[indexColumn].upgradeTypes;
        List<UpgradeSave> upgradeSaves = new List<UpgradeSave>();
        for (int i = 0; i < data.Length; i++)
        {
            upgradeSaves.Add(new UpgradeSave(data[i]));
        }
        return upgradeSaves;
    }
    public List<UpgradeSave> GetUpgradeSave(int indexTower, int indexColumn)
    {
        return tablesSave.dataTablesSave[indexTower].columnSaves[indexColumn].types;
    }

    public void Unlock(int indexTower, int indexColumn)
    {
        tablesSave.dataTablesSave[indexTower].columnSaves[indexColumn].UnLock();
        Save();
    }
    public void Purchase(int indexTower, int indexColumn)
    {
        TableSave tableSave = tablesSave.dataTablesSave[indexTower];
        ColumnSave colSave = tableSave.columnSaves[indexColumn];
        if (DataPersist.Money < tableTower.pricesTower[indexTower].list[indexColumn].priceUnlock)
            return;
        colSave.Purchase();
        DataPersist.Money -= tableTower.pricesTower[indexTower].list[indexColumn].priceUnlock;
        PopupUpgrade.instance.UpdateTxtMoney();
        colSave.UnLock();
        if (colSave.types.Count > 0)
        {
            colSave.types[0].UnLock();
        }
        if(indexColumn < 2)
        {
            tableSave.columnSaves[indexColumn + 1].UnLock();
        }
        Save();
    }
    public void PurchaseUpgrade(int indexTower, int indexColumn, UpgradeType type)
    {
        TableSave tableSave = tablesSave.dataTablesSave[indexTower];
        ColumnSave colSave = tableSave.columnSaves[indexColumn];
        if (DataPersist.Money < tableTower.pricesTower[indexTower].list[indexColumn].priceUpgrades[indexColumn])
            return;
        colSave.Purchase();
        UpgradeSave a = colSave.types.Find(x => x.type == type);
        a.Purchase();
        DataPersist.Money -= tableTower.pricesTower[indexTower].list[indexColumn].priceUpgrades[indexColumn];
        PopupUpgrade.instance.UpdateTxtMoney();
        int index = colSave.types.IndexOf(a);
        if(index < 2)
        {
            colSave.types[index + 1].UnLock();
        }
        Save();
    }
    private void Save()
    {
        DataPersist.JsonTables = tablesSave.ToString();
    }
    public bool IsUnLocked(int indexTower, int indexColumn)
    {
        return tablesSave.dataTablesSave[indexTower].columnSaves[indexColumn].unLocked;
    }
    public bool IsPurchased(int indexTower, int indexColumn)
    {
        return tablesSave.dataTablesSave[indexTower].columnSaves[indexColumn].purchased;
    }
}
