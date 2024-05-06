using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    TOWER,
    UPGRADE,
    ABILITY
}
[Serializable]
public class CellScriptable
{
    public int price;
    public CellType type;
    public int indexColumn;
    public int indexCell;
}


[CreateAssetMenu(fileName = "TableData", menuName = "Data/Table")]
public class TableScriptable : ScriptableObject
{
    public List<ColumnSctiptable> list;
}