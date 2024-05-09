using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="Sprites", menuName = "Data/Sprites")]
public class ArraySprite : ScriptableObject
{
    public Sprite[] array;
}

