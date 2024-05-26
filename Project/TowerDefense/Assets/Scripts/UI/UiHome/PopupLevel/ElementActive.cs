using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementActive : MonoBehaviour
{
    [SerializeField] private Image[] images;

    private void SetDeActive()
    {
        foreach (Image item in images)
        {
            item.sprite = Uihome.instance.spriteGray;
        }
    }
    [Button]
    public void Test()
    {
        SetActive(1);
    }
    public void SetActive(int amount = 3)
    {
        SetDeActive();
        for (int i = 0; i < amount; i++)
        {
            images[i].sprite = Uihome.instance.spriteGreen;
        }
    }
}
