using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarWin : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    private int amount;
    private IEnumerator ShowStar()
    {
        Hide();
        for(int i = 0; i <= amount; i++)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            stars[i].enabled = true;
        }
    }
    public void Show(int amount)
    {
        if(amount == 10)
        {
            this.amount = 2;
        }
        else if(amount < 10 && amount > 5)
        {
            this.amount = 1;
        }
        else
        {
            this.amount = 0;
        }
        LevelManager.instance.SetStarLeve(this.amount);
        StartCoroutine(ShowStar());
    }

    private void Hide()
    {
        foreach(Image item in stars)
        {
            item.enabled = false;
        }
    }
}
