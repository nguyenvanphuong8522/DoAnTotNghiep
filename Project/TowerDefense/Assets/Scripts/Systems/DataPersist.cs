using System.Collections.Generic;
using UnityEngine;

public class DataPersist
{
    public static int Level
    {
        get => PlayerPrefs.GetInt("LEVEL", 0);
        set => PlayerPrefs.SetInt("LEVEL", value);
    }
    public static int TeleportLevel
    {
        get => PlayerPrefs.GetInt("TELEPORT", 0);
        set => PlayerPrefs.SetInt("TELEPORT", value);
    }
    public static int BoomLevel
    {
        get => PlayerPrefs.GetInt("BOOM", 0);
        set => PlayerPrefs.SetInt("BOOM", value);
    }
    public static string StringJsonTables
    {
        get => PlayerPrefs.GetString("TABLE");
        set => PlayerPrefs.SetString("TABLE", value);
    }
}
