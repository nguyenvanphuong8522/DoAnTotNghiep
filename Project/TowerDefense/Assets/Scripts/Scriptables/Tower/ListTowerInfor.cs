using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "dataTowerInfors", menuName ="Data/DataTowerInfors")]
public class ListTowerInfor: ScriptableObject
{
    public List<TowerInfor> dataTowers;
}
