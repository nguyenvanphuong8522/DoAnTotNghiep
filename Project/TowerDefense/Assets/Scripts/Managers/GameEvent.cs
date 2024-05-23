using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    public static Action returnLevel;
    public static Action startLevel;

    public static void CallReturnLevel()
    {
        returnLevel.Invoke();
    }
    public static void CallStartLevel()
    {
        startLevel.Invoke();
    }
}
