using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    public ButtonEffectLogic btn;
    private void OnEnable()
    {
        btn.onClick.AddListener(End);
    }
    public void End()
    {
        Save();
        UiGameplay.instance.btnPause.UnPause();
        GameTutorial.instance.gameObject.SetActive(false);
    }

    public void Save()
    {
        DataPersist.Tutorialed = 2;
    }
}
