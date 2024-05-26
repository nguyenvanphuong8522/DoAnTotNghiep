using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : Singleton<Loading>
{
    protected override void Awake()
    {
        base.Awake();
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(DelayHide());
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(1.85f);
        Hide();
    }
}
