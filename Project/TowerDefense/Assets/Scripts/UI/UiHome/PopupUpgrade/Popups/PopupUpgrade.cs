using DG.Tweening;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;

    [Header("Reference")]
    public TableTower tableTower;
    public TableAbility tableAbility;
    public Board board;
    public RectTransform boundMove;
    [SerializeField] private Text txtMoney;
    

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    private void OnEnable()
    {
        tableTower.UpdateTable(0);
        boundMove.anchoredPosition = new Vector3(0, -17, 0);
        UpdateTxtMoney();
    }
    
    public override void Show(object data = null)
    {
        _isShow = true;
        gameObject.SetActive(true);
    }
    public void SetBoundMove(Vector3 pos)
    {
        boundMove.DOAnchorPos(pos, 0.25f);
    }
    public void UpdateTxtMoney()
    {
        txtMoney.text = "$ " + DataPersist.Money;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        transform.DOKill();
    }
}
