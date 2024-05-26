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
    public Gun gun;

    private void OnEnable()
    {
        EnableRange();
        SetData();
    }
    private void SetData()
    {
        TowerInfor data = GameManager.instance.towersData.dataTowers[indexTower].dataTowers[indexLevel];
        coinUpdate = data.coinUpgrade;
        coinSell = data.coinSell;
        List<UpgradeSave> listUpgrade = DataHangarSave.instance.tablesSave.dataTablesSave[indexTower].columnSaves[indexLevel].types;
        UpgradeSave upgradeSave = listUpgrade.Find(x => x.type == UpgradeType.RANGE);
        if (upgradeSave != null)
        {
            if (upgradeSave.unLocked == true)
            {
                range.localScale = (data.range + (data.range * 0.1f)) * Vector3.one;
            }
            else
            {
                range.localScale = data.range * Vector3.one;
            }
        }
        

        if(gun != null)
        {
            if (listUpgrade.Find(x => x.type == UpgradeType.DAME).unLocked == true)
            {
                gun.atk = (int)(data.damge + (data.damge * 0.1f));
            }
            else
            {
                gun.atk = data.damge;
            }
            if (listUpgrade.Find(x => x.type == UpgradeType.DAME).unLocked == true)
            {
                gun.rate = data.fireRate - (data.fireRate * 0.1f);
            }
            else
            {
                gun.rate = data.fireRate;
            }
        }

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
        uiTowerUpgrade.Unlock();
        uiTowerUpgrade.AddListener(UpdateTower, Sell);
        uiTowerUpgrade.UpDateUi(transform.position, range.localScale);
        uiTowerUpgrade.UpdatePrice(coinUpdate, coinSell);
        if (indexLevel < 2)
        {
            if (!DataHangarSave.instance.tablesSave.dataTablesSave[indexTower].columnSaves[indexLevel + 1].purchased)
            {
                uiTowerUpgrade.LockUpgrade();
            }
            if (LevelManager.instance.listLevelData.levels[LevelManager.instance.indexLevel].contraintTower[indexTower] - 1 == indexLevel)
            {
                uiTowerUpgrade.LockUpgrade();
            }
        }

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
        if (curLevel.money >= coinUpdate)
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
