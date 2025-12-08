using System.Collections.Generic;
using UnityEngine;

public static class GameSettingsUtilities
{
    // TODO: Move this using unity scripting
    public const string IosGameId = "6000024";
    public const string AndroidGameId = "6000025";
    public const bool IsAdTesting = true;
    public const string AndroidAdBannerId = "Banner_Android";
    public const string IosAdBannerId = "Banner_iOS";
    public const string AndroidAdRewardedId = "Rewarded_Android";
    public const string IosAdRewardedId = "Rewarded_iOS";

    public const bool IsTesting = false;
    public const int TotalColumn = 8;
    public const int TotalGeneratedTile = 80;
    public const int TotalAddedTile = 32;
    public const int TotalStrikeScore = 10;
    public const int TotalScore = 30;
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
