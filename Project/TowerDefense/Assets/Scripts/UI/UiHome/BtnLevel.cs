using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnLevel : MonoBehaviour
{
    [SerializeField] private ButtonEffectLogic btn;
    [SerializeField] private int lv;
    [SerializeField] GameObject[] stars;
    [SerializeField] private GameObject lockLevel;
    [SerializeField] private Image image;

    public void UpdateStarLevel()
    {
        SetStar(LevelManager.instance.starsLevel.levelStars[lv]);
    }
    private void Start()
    {
        btn.onClick.AddListener(EventClick);
    }
    public void SetData(int lv)
    {
        this.lv = lv;   
    }

    public void EventClick()
    {
        Uihome.instance.popUpManager.popUpLevel.popupPreview.Show(lv);
    }
    public void SetStar(int amount)
    {
        Hide();
        
        if(lv <= DataPersist.Level)
        {
            lockLevel.SetActive(false);
            image.raycastTarget = true;
            if(amount > -1)
            {
                stars[amount].SetActive(true);
            }
        }
    }

    public void Hide()
    {
        foreach (var item in stars)
        {
            item.SetActive(false);  
        }
    }
}
