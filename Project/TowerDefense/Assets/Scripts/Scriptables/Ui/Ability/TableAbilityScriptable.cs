using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CellAbilityScriptable
{
    public int index;
    public int level;
}
[Serializable]
public class RowAbilityScriptable
{
    public CellAbilityScriptable[] column;
}
[CreateAssetMenu(fileName ="TableAbility", menuName ="Data/Table Ability")]
public class TableAbilityScriptable : ScriptableObject
{
    public List<RowAbilityScriptable> table;
}
