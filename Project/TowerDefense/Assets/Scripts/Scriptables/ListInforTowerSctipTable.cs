using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class InforTowerScriptable
{
    public string Name;
    public string Description;
}

[CreateAssetMenu(fileName = "InforTowerData", menuName = "Data/Infor Tower")]
public class ListInforTowerSctipTable : ScriptableObject
{
    public List<InforTowerScriptable> listDataTower;
}



