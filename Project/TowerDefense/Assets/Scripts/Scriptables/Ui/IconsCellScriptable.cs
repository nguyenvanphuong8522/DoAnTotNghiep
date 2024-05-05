using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ArraySprite
{
    public Sprite[] array;
}

[CreateAssetMenu(fileName = "IconsCell", menuName ="Data/Icons Cell")]
public class IconsCellScriptable : ScriptableObject
{
    public Sprite[] optionSprites;
    public List<ArraySprite> towerSprites;
    public List<ArraySprite> abilitySprites;
}

