using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public int coinUpdate;
    public int coinSell;
    public Level curLevel;
    public Transform range;
    public int indexTower;
    private UiTowerUpgrade uiTowerUpgrade;
    public CircleCollider2D rangeCollider;
    private void OnEnable()
    {
        EnableRange();
    }

    private void Start()
    {
        uiTowerUpgrade = UiTowerUpgrade.instance;
        curLevel = LevelManager.instance.curLevel;
    }
    private void OnMouseUp()
    {
        if(!Utils.IsPointerOverUIElement())
        {
            Show();
        }
    }
    public void Show()
    {
        if (Ground.instance.uiBuildTower.isShowing)
        {
            Ground.instance.uiBuildTower.SetActiveUiBuilder(false);
        }
        else
        {
            uiTowerUpgrade.AddListener(UpdateTower, Sell);
            uiTowerUpgrade.UpDateUi(transform.position, range.localScale);
        }
    }
    public void CheckEnoughCoin()
    {
        int curCoin = curLevel.coin;
        if(curCoin >= coinUpdate)
        {

        }
    }
    public void ReturnToPool()
    {
        indexTower = 0;
        uiTowerUpgrade.SetShowHide();
        EnableRange(false);
        ObjectPool.instance.Return(gameObject);
    }
    public void UpdateTower()
    {
        ObjectPool.instance.Get(ObjectPool.instance.towers[0].pools[++indexTower], transform.position);
        ReturnToPool();
    }

    public void Sell()
    {
        curLevel.SetCoin(coinSell, false);
        ReturnToPool();
    }
    private void EnableRange(bool value = true)
    {
        rangeCollider.enabled = value;
    }
}
