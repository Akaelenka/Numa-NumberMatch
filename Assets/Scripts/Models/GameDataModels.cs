using System;
using System.Collections.Generic;

namespace NumaModels
{
    [Serializable]
    public class GameDataModel
    {
        public List<int> TileData { get; set; }
        public int TargetScore { get; set; } = -1;
        public int CurrentScore { get; set; } = -1;
        public int HelpCount { get; set; } = -1;
    }

    public enum EGameSelection
    {
        None,
        Start,
        Continue,
    }
}

