using DG.Tweening;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;

    [Header("Reference")]
    public TableTower tableTower;
    public TableAbility tableAbility;
    public Board board;
    public RectTransform boundMove;
    private DataTablesSave tablesSave;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        CheckInitData();
    }
    private void OnEnable()
    {
        tableTower.UpdateTable(0);
        boundMove.anchoredPosition = new Vector3(0, -17, 0);
    }
    #region ShowJsonLog
    [Button]
    public void ShowJson()
    {
        Debug.Log(DataPersist.JsonTables);
    }
    #endregion
    public void CheckInitData()
    {
        if(!PlayerPrefs.HasKey("TABLE"))
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
        Purchase(0, 0);
        Purchase(0, 1);
    }
    private DataTablesSave GetOldData()
    {
        return JsonConvert.DeserializeObject<DataTablesSave>(DataPersist.JsonTables);
    }
    public List<UpgradeSave> GetUpgradeType(int indexTower, int indexColumn)
    {
        UpgradeType[] data = tableTower.towerTableData[indexTower].columns[indexColumn].upgradeTypes;
        List<UpgradeSave> upgradeSaves = new List<UpgradeSave>();
        for(int i = 0;i < data.Length;i++)
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
        colSave.Purchase();
        colSave.UnLock();
        if (colSave.types.Count > 0)
        {
            colSave.types[0].UnLock();
        }
        tableSave.columnSaves[indexColumn + 1].UnLock();
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

    public override void Show(object data = null)
    {
        _isShow = true;
        gameObject.SetActive(true);
    }
    public void SetBoundMove(Vector3 pos)
    {
        boundMove.DOAnchorPos(pos, 0.25f);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        transform.DOKill();
    }
}
