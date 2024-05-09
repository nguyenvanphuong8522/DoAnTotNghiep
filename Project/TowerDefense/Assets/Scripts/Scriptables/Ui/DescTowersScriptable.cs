using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DescTowerSctiptable
{
    public string Name;
    public string Description;
}
[Serializable]
public class InforTowerPriceScriptable : DescTowerSctiptable
{
    public int price;
}

[CreateAssetMenu(fileName = "InforTowerData", menuName = "Data/Infor Tower")]
public class DescTowersScriptable : ScriptableObject
{
    public List<DescTowerSctiptable> list;
}



