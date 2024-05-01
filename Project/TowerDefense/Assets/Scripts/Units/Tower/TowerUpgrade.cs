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
    public int indexLevel;
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
        uiTowerUpgrade.AddListener(UpdateTower, Sell);
        uiTowerUpgrade.UpDateUi(transform.position, range.localScale);
        uiTowerUpgrade.Show();
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
        uiTowerUpgrade.Hide();
        EnableRange(false);
        ObjectPool.instance.Return(gameObject);
    }
    public void UpdateTower()
    {
        int index = indexLevel + 1;
        ObjectPool.instance.Get(ObjectPool.instance.towers[indexTower].pools[index], transform.position);
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
