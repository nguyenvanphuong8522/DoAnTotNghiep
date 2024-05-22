using DG.Tweening;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAbilitySave
{
    public bool unLocked;
    public bool purchased;
    public void Unlock()
    {
        unLocked = true;
    }

    public void Purchase()
    {
        purchased = true;
    }
}

public class RowSave
{
    public List<CellAbilitySave> cells;
    public RowSave() {}
    public RowSave(int amount)
    {
        cells = new List<CellAbilitySave>();
        for(int i = 0; i < amount; i++)
        {
            cells.Add(new CellAbilitySave());
        }
    }
}
public class TableAbilitySave
{
    public List<RowSave> rows;
    public TableAbilitySave() {}
    public TableAbilitySave(int amount)
    {
        rows = new List<RowSave>();
        for (int i = 0; i < amount; i++)
        {
            rows.Add(new RowSave(2));
        }
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
public class UpgradeSave
{
    public bool unLocked;
    public bool purchased;
    public UpgradeType type;
    public UpgradeSave(){}
    public UpgradeSave(UpgradeType type)
    {
        this.type = type;
    }
    public void UnLock()
    {
        unLocked = true;
    }
    public void Purchase()
    {
        purchased = true;
    }
}
public class ColumnSave
{
    public bool unLocked;
    public bool purchased;
    public List<UpgradeSave> types;
    public ColumnSave()
    {
        types = new List<UpgradeSave>();
    }
    public ColumnSave(List<UpgradeSave> types)
    {
        this.types = types;
    }

    public void UnLock()
    {
        unLocked = true;
    }
    public void Purchase()
    {
        purchased = true;
    }
}
public class TableSave
{
    public List<ColumnSave> columnSaves;
    public TableSave()
    {
        columnSaves = new List<ColumnSave>();
    }
    public void AddColumn(ColumnSave column)
    {
        columnSaves.Add(column);
    }
    public void AddColumn(List<UpgradeSave> types)
    {
        if (types.Count == 0)
        {
            AddColumn(new ColumnSave());
            return;
        }
        AddColumn(new ColumnSave(types));
    }
}

public class DataTablesSave
{
    public List<TableSave> dataTablesSave;
    public DataTablesSave()
    {
        dataTablesSave = new List<TableSave>();
    }
    public void AddTable(TableSave tableSave)
    {
        dataTablesSave.Add(tableSave);
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
