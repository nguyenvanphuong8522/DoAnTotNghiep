using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static Action returnLevel;

    public static void CallReturnLevel()
    {
        returnLevel.Invoke();
    }
}
