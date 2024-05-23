using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectDollar : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        canvas.worldCamera = Camera.main;
        
        transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() => {

            text.DOFade(0.7f, 0.2f).OnComplete(() => { DelayReturnToPool(); });
        });
        
    }
    public void SetText(int coin)
    {
        text.text = "+" + coin;
    }
    private void DelayReturnToPool()
    {
        ObjectPool.instance.Return(gameObject);
    }
    private void OnDisable()
    {
        transform.DOKill();
        text.color = Color.yellow;
    }
}
