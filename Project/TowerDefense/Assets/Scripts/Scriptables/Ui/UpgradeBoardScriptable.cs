using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptionTye
{
    TOWER,
    UPGRADE,
    ABILITY
}
[Serializable]
public class BtnUpgradeScriptable
{
    public int price;
    public OptionTye type;
    public int index;
}


[CreateAssetMenu(fileName = "DataUpgradeBoard", menuName = "Data/Data Upgrade Board")]
public class UpgradeBoardScriptable : ScriptableObject
{
    public List<ColumnSctiptable> listColumn;
}