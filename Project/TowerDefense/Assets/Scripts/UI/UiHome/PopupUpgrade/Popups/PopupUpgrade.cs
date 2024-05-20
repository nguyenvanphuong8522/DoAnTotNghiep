using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUpgrade : BasePopup
{
    public static PopupUpgrade instance;

    [Header("Reference")]
    public TableTower tableTower;
    public TableAbility tableAbility;
    public Board board;
    public RectTransform boundMove;
    
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    public override void Show(object data = null)
    {
        _isShow = true;
        gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        tableTower.UpdateTable(0);
        boundMove.anchoredPosition = new Vector3(0, -17, 0);
    }
    public void SetBoundMove(Vector3 pos)
    {
        boundMove.DOAnchorPos(pos, 0.25f);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        transform.DOKill();
    }
}
