using System;
using UnityEngine;




[CreateAssetMenu(fileName = "PriceTower", menuName = "Data/PriceTower")]
public class PriceScriptable : ScriptableObject
{
    public int priceUnlock;
    public int[] priceUpgrades;
}

[Serializable]
public class Prices
{
    public PriceScriptable[] list;
}
