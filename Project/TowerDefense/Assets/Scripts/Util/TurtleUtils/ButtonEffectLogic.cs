﻿using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
#if UNITY_EDITOR
using UnityEditor;

#endif

[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class ButtonAttribute : PropertyAttribute
{
}

public class ButtonEffectLogic : Button
{
    public bool hasEffect = false;
    public UnityEvent onEnter = new UnityEvent(),
        onDown = new UnityEvent(),
        onExit = new UnityEvent(),
        onUp = new UnityEvent();

    Vector3 initScale;

    protected override void Awake()
    {
        initScale = transform.localScale;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        onDown.Invoke();
        EffectDown();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        onEnter.Invoke();
        EffectDown();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        onUp.Invoke();
        EffectUp();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        onExit.Invoke();
        EffectUp();
    }


    public virtual void EffectDown()
    {
        //SoundManageLogic.Instance?.PlayButton(SoundManageLogic.Instance.btnClickSound);
        //ScaleUp();
    }

    public virtual void EffectUp()
    {
        ScaleDown();
    }

    public virtual void ScaleUp()
    {
        if (hasEffect)
        {
            transform.localScale = initScale;
        }
    }

    public virtual void ScaleDown()
    {
        if (hasEffect)
        {
            transform.localScale = initScale * 0.9f;
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ButtonEffectLogic))]
public class ButtonEffectLogicEditor : Editor
{
    ButtonEffectLogic mtarget;

    private void OnEnable()
    {
        mtarget = target as ButtonEffectLogic;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
#endif