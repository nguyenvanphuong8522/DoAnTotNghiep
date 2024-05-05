using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class InforTowerSctiptable
{
    public string Name;
    public string Description;
}
[Serializable]
public class InforTowerPriceScriptable : InforTowerSctiptable
{
    public int price;
}

[CreateAssetMenu(fileName = "InforTowerData", menuName = "Data/Infor Tower")]
public class InforTowersScriptable : ScriptableObject
{
    public List<InforTowerSctiptable> list;
}



