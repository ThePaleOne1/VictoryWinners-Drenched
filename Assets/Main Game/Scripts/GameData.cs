using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int daysAlive;

    public GameData(SunGoku sungoku)
    {
        daysAlive = sungoku.daysAlive;
    }

}


