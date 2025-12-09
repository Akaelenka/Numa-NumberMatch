using System;
using UnityEngine;

namespace NumaModels
{
    [CreateAssetMenu(fileName = "ExpChart", menuName = "Scriptable Objects/Numa/ExpChart")]
    public class ExpChartModel : ScriptableObject
    {
        public int[] ExpList;
    }

    [Serializable]
    public class PlayerDataModel
    {
        public string SaveType { get; set; } = "PlayerData";
        public string Username { get; set; }
        public int ExpValue { get; set; } = -1;
    }
}
