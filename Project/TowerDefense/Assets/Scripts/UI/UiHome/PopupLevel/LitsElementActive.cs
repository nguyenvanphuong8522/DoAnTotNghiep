using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitsElementActive : MonoBehaviour
{
    [SerializeField] private ElementActive[] elementActives;
    public void SetListElement(int index)
    {
        int[] arr = LevelManager.instance.listLevelData.levels[index].contraintTower;
        for(int i = 0; i < arr.Length; i++)
        {
            elementActives[i].SetActive(arr[i]);
        }
    }
}
