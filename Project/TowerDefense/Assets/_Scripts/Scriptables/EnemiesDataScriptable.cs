using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies Data", menuName = "Data/Enemies")]
public class EnemiesDataScriptable : ScriptableObject
{
    public List<EnemyData> enemies;
}

[Serializable]
public class EnemyData
{
    public string name;
    public int health;
    public float speedMove;
}
public enum EnemyName
{
    SmallSolider,
    BigSolider,
    SmallCar,
    BigCar,
    SmallTank,
    BigTank
}
