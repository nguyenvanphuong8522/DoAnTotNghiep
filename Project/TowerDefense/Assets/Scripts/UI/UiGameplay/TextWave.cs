using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextWave : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private Coroutine coroutine;
    private void OnEnable()
    {
        GameEvent.returnLevel += StopDelay;
    }
    public void UpdateText()
    {
        int index = LevelManager.instance.curLevel.waveManager.waveIndex;
        text.text = "WAVE " + index;
    }

    public void Show()
    {
        UpdateText();
        gameObject.SetActive(true);
        transform.DOScale(1.1f, .5f).OnComplete(() => { coroutine = StartCoroutine(Hide()); });
        
    }
    public void StopDelay()
    {
        transform.DOKill();
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        transform.localScale = 0.75f * Vector3.one;
        gameObject.SetActive(false);
    }
    public IEnumerator Hide()
    {
        yield return new WaitForSeconds(1f);
        transform.localScale = 0.75f * Vector3.one;
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        GameEvent.returnLevel -= StopDelay;
        transform.DOKill();
    }
}
