using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NumaModels
{
    [Serializable]
    public class GameDataModel
    {
        public List<int> TileData { get; set; }
        public int TargetScore { get; set; }
        public int CurrentScore { get; set; }
    }

    public enum EGameSelection
    {
        None,
        Start,
        Continue,
    }
}

