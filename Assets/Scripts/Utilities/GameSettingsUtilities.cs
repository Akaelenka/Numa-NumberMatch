using System.Collections.Generic;

public class GameSettingsUtilities
{
    private static bool _IsTesting = false;
    private static int _totalColumn = 8;
    private static int _totalGeneratedTile = 80;
    private static int _totalAddedTile = 32;
    private static int _totalStrikeScore = 10;
    private static int _totalScore = 150;

    public static bool IsTesting 
    { 
        get { return _IsTesting; }
    }
    public static int TotalColumn 
    { 
        get { return _totalColumn; }
    }
    public static int TotalGeneratedTile 
    {
        get { return _totalGeneratedTile; }
    }
    public static int TotalAddedTile
    {
        get { return _totalAddedTile; }
    }

    public static int TotalStrikeScore
    { 
        get { return _totalStrikeScore; } 
    }

    public static int TotalScore
    {
        get { return _totalScore; }
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
