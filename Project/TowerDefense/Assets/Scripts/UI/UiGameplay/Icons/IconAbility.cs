using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconAbility : MonoBehaviour
{
    [SerializeField] private Image iconBlack;
    [SerializeField] private Image iconGray;
    [SerializeField] private float delta;
    [SerializeField] private BtnPutBoom btnPutAbility;

    private void OnEnable()
    {
        GameEvent.startLevel += Lock;
    }
    [Button]
    public void Lock()
    {
        iconBlack.enabled = true;
        iconGray.enabled = true;
        iconBlack.fillAmount = 1;
        btnPutAbility.Lock();
        StartCoroutine(Rotate());
    }

    public void Unlock() 
    {
        iconBlack.enabled = false;
        iconGray.enabled = false;
        btnPutAbility.Unlock();
    }
    public IEnumerator Rotate()
    {
        while(iconBlack.fillAmount > 0)
        {
            iconBlack.fillAmount -= delta;
            yield return new WaitForSeconds(0.25f);
        }
        Unlock();
    }
    private void OnDisable()
    {
        GameEvent.startLevel -= Lock;
    }
}
