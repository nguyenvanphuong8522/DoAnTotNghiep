using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HealBar : MonoBehaviour
{
    [SerializeField] private Image fill;
    [SerializeField] private Ihealth health;
    private float maxHeal;
    [SerializeField] private GameObject objHealBar;
    private void Start()
    {
        health = GetComponent<Ihealth>();
        maxHeal = health.health;
    }
    public void UpdateHealBar()
    {
        Show();
        float percent = health.health / maxHeal;
        fill.fillAmount = percent;
    }
    public void ResetBar()
    {
        fill.fillAmount = 1;
    }
    public void Show()
    {
        if(!objHealBar.activeSelf)
        {
            objHealBar.SetActive(true);
        }
    }
    public void Hide()
    {
        objHealBar.SetActive(false);
    }

    private void OnDisable()
    {
        ResetBar();
        Hide();
    }
}
