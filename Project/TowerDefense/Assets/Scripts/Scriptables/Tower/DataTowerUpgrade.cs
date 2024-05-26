using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerInfor
{
    public int damge;
    public float range;
    public float fireRate;
    public int coinUpgrade;
    public int coinSell;
}
[CreateAssetMenu(fileName ="DataTowers", menuName = "Data/Tower Infor Attack")]
public class DataTowerUpgrade : ScriptableObject
{
    public List<ListTowerInfor> dataTowers;
}
