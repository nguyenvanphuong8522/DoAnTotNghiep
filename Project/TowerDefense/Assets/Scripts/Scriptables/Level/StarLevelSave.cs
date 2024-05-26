using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLevelSave
{
    public int[] levelStars;
    public StarLevelSave()
    {
        levelStars = new int[20];
        for(int i = 0; i < 20; i++)
        {
            levelStars[i] = -1;
        }
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
