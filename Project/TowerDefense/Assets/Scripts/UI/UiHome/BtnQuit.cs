using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnQuit : MonoBehaviour
{
    [SerializeField] private Button btnQuit;
    private void Awake()
    {
        btnQuit.onClick.AddListener(Quit);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
