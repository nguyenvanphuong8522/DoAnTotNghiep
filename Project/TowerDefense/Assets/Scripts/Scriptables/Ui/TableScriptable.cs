using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    DAME,
    RANGE,
    RATE
}


[CreateAssetMenu(fileName = "TableData", menuName = "Data/Table")]
public class TableScriptable : ScriptableObject
{
    public List<ColumnSctiptable> columns;
}