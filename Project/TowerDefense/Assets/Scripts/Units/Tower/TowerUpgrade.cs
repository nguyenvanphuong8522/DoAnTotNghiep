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
    private Vector3 preClick;
    private void OnMouseDown()
    {
        preClick = ConvertToGridPos.instance.GetMousePos();
    }
    private void OnMouseUp()
    {
        Vector3 curClick = ConvertToGridPos.instance.GetMousePos();
        float distance = Vector3.Distance(curClick, preClick);

        if (!Utils.IsPointerOverUIElement() && distance <= 0.00001f)
        {
            Show();
        }
    }
    public void Show()
    {
        uiTowerUpgrade.AddListener(UpdateTower, Sell);
        uiTowerUpgrade.UpDateUi(transform.position, range.localScale);
        uiTowerUpgrade.UpdatePrice(coinUpdate, coinSell);
        uiTowerUpgrade.Show();
    }
    public void ReturnToPool()
    {
        uiTowerUpgrade.Hide();
        EnableRange(false);
        ObjectPool.instance.Return(gameObject);
    }
    public void UpdateTower()
    {
        if(curLevel.money >= coinUpdate)
        {
            int index = indexLevel + 1;
            curLevel.IncreaseCoin(coinUpdate, false);
            ObjectPool.instance.Get(ObjectPool.instance.towers[indexTower].pools[index], transform.position);
            ReturnToPool();
        }
    }
    public void Sell()
    {
        curLevel.IncreaseCoin(coinSell);
        ReturnToPool();
    }
    private void EnableRange(bool value = true)
    {
        rangeCollider.enabled = value;
    }
}
