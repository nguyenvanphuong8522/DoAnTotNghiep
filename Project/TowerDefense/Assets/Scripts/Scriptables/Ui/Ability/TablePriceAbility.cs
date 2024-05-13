using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RowPriceAbility
{
    public int[] cells;
}

[CreateAssetMenu(fileName ="TablePriceAbility", menuName ="Data/Table Price Ability")]
public class TablePriceAbility : ScriptableObject
{
    public RowPriceAbility[] rows;
}
