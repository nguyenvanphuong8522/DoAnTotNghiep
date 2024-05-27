using System.Collections.Generic;
using UnityEngine;

public class DataPersist
{
    public static int Tutorialed
    {
        get => PlayerPrefs.GetInt("TUTORIAL", -1);
        set => PlayerPrefs.SetInt("TUTORIAL", value);
    }
    public static float VolumeMusic
    {
        get => PlayerPrefs.GetFloat("MUSIC", 1);
        set => PlayerPrefs.SetFloat("MUSIC", value);
    }
    public static float VolumeSound
    {
        get => PlayerPrefs.GetFloat("SOUND", 1);
        set => PlayerPrefs.SetFloat("SOUND", value);
    }
    public static int Level
    {
        get => PlayerPrefs.GetInt("LEVEL", 20);
        set => PlayerPrefs.SetInt("LEVEL", value);
    }
    public static int Money
    {
        get => PlayerPrefs.GetInt("MONEY", 0);
        set => PlayerPrefs.SetInt("MONEY", value);
    }
    public static string JsonTables
    {
        get => PlayerPrefs.GetString("TABLE");
        set => PlayerPrefs.SetString("TABLE", value);
    }
    public static string JsonAbility
    {
        get => PlayerPrefs.GetString("ABILITY");
        set => PlayerPrefs.SetString("ABILITY", value);
    }
    public static string JsonStarLevel
    {
        get => PlayerPrefs.GetString("LEVELSTAR");
        set => PlayerPrefs.SetString("LEVELSTAR", value);
    }
}
