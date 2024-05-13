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
    
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    private void Start()
    {
        tableTower.UpdateTable(0);
    }
}
