using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTalk : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private RectTransform character;
    [SerializeField] private RectTransform dialog;
    public void SetText(string text)
    {
        this.text.text = text;
    }
    public void Move()
    {
        HideDialog();
    }
    public void MoveCharacter(float x, float duration, bool active = false)
    {
        character.DOAnchorPosX(x, duration).OnComplete(()=> {
            if(active)
            {
                ShowCharacter();
                return;
            }
            HideCharacter();
        }).SetUpdate(true);
    }
    public void Hide()
    {
        HideDialog();
        MoveCharacter(-1000, 1.5f);
    }
    public void HideDialog()
    {
        dialog.gameObject.SetActive(false);
    }
    public void ShowDialog(float duration)
    {
        StartCoroutine(DelayShowDiaLog(duration));
    }
    private IEnumerator DelayShowDiaLog(float duration)
    {
        yield return new WaitForSecondsRealtime(1);
        dialog.gameObject.SetActive(true);
    }
    public void HideCharacter()
    {
        character.gameObject.SetActive(false);
    }
    public void ShowCharacter()
    {
        character.gameObject.SetActive(true);
    }
}
