using System.Collections.Generic;
using UnityEngine;

public static class GameSettingsUtilities
{
    public const bool IsTesting = false;
    public const int TotalColumn = 8;
    public const int TotalGeneratedTile = 80;
    public const int TotalAddedTile = 32;
    public const int TotalStrikeScore = 10;
    public const int TotalScore = 150;
    public static string _path = Application.persistentDataPath + "/GameData.numa";

    public static string Path
    {
        get { return _path; } 
    }

    public static List<int> GetTestValue()
    {
        List<int> listValue = new List<int>() 
        { 
            0, 0, 0, 0, 0, 0, 0, 8, 
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8,
            0, 0, 0, 0, 0, 0, 0, 8
        };

        return listValue;
    }
    
}
