using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BtnTowerSelect : MonoBehaviour
{
    public int indexCell;
    public Button btn;
    public virtual void Start()
    {
        btn.onClick.AddListener(UpdateBoard); 
    }

    public abstract void UpdateBoard();
    #region Validate
    private void OnValidate()
    {
        btn = GetComponent<ButtonEffectLogic>();
    }
    #endregion
}
