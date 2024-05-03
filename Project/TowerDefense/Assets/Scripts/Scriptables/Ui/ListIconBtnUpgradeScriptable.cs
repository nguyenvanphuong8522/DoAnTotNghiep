using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ArraySprite
{
    public Sprite[] array;
}

[CreateAssetMenu(fileName = "ListIconBtnUpgrade", menuName ="Data/ListIconBtnUpgrade")]
public class ListIconBtnUpgradeScriptable : ScriptableObject
{
    public Sprite[] optionSprites;
    public List<ArraySprite> towerSprites;
    public List<ArraySprite> abilitySprites;
}

