using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IconsCell", menuName ="Data/Icons Cell")]
public class IconsCellScriptable : ScriptableObject
{
    public ArraySprite optionSprites;
    public List<ArraySprite> towerSprites;
    public List<ArraySprite> abilitySprites;
}

