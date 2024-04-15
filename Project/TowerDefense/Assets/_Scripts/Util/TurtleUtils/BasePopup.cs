using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BasePopup : MonoBehaviour
{
    public Transform main;
    public Button btnClose;
    public bool _isShow = false;

    protected float timeShow = 0.25f;

    protected virtual void Awake()
    {
        if (btnClose)
        {
            btnClose.onClick.AddListener(Hide);
        }
    }

    public virtual void Show(object data = null)
    {
        _isShow = true;
        if (main != null)
        {
            //main.transform.localScale = Vector3.one * 0.7f;
            main.transform.DOScale(1, timeShow).From(Vector3.one * .5f);
        }
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        _isShow = false;
        gameObject.SetActive(false);
    }

    protected virtual void OnDisable()
    {
        main?.DOKill();
    }
}
