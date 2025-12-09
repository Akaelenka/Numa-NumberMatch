using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using NumaModels;

public class SaveManager : MonoBehaviour
{
    private GameDataModel _data;
    private PlayerDataModel _player;
    private Queue<string> _saveQueue = new Queue<string>();

    private bool _isSaving = false;

    private void Awake()
    {
        _data = new GameDataModel();
        _player = new PlayerDataModel();

        PanelEM.OnChangePanel += CheckDataFile;
        PanelEM.OnStartGame += ResetData;
        PanelEM.OnFinishGame += DeleteData;

        SaveEM.OnSaveData += SaveData;
        SaveEM.OnLoadData += LoadData;

        SaveEM.OnSavePlayerData += SavePlayerData;
        SaveEM.OnLoadPlayerData += LoadPlayerData;
    }

    private void Update()
    {
        if (_saveQueue.Count > 0 && !_isSaving) 
        {
            _isSaving = true;

            var json = _saveQueue.Dequeue();

            if (json.Contains("\"SaveType\":\"PlayerData\""))
            {
                SaveUtilities.SaveData(GameSettingsUtilities._playerPath, json);
            }
            else //if (json.Contains("\"SaveType\":\"GameData\""))
            {
                SaveUtilities.SaveData(GameSettingsUtilities._gamedataPath, json);
            }

            Debug.Log("trying to save" + json);

            _isSaving = false;
        }
    }

    #region Game Data

    private void ResetData()
    {
        _data = new GameDataModel();
    }

    private void LoadData()
    {
        string data = SaveUtilities.LoadData(GameSettingsUtilities._gamedataPath);

        if (data != null)
        {
            Debug.Log(data);

            _data = JsonConvert.DeserializeObject<GameDataModel>(data);

            Debug.Log(JsonConvert.SerializeObject(_data, Formatting.Indented));

            SaveEM.LoadDataResult(_data);
        }

        if (data == null) 
        {
            SaveEM.LoadDataResult(null);
        }
    }

    private void SaveData(GameDataModel data)
    {
        if (data == null)
        {
            return;
        }

        if (data.TargetScore >= 0)
        {
            _data.TargetScore = data.TargetScore;
        }
        if (data.CurrentScore >= 0)
        {
            _data.CurrentScore = data.CurrentScore;
        }
        if (data.HelpCount >= 0)
        {
            _data.HelpCount = data.HelpCount;
        }
        if (data.TileData != null)
        {
            _data.TileData = new List<int>();
            _data.TileData.AddRange(data.TileData);
        }

        var json = JsonConvert.SerializeObject(_data);
        _saveQueue.Enqueue(json);
    }

    private void DeleteData()
    {
        SaveUtilities.DeleteData(GameSettingsUtilities._gamedataPath);
    }

    private void CheckDataFile(EPanelType state)
    {
        if (state == EPanelType.MainMenu)
        {
            SaveEM.IsDataExist(SaveUtilities.IsExist(GameSettingsUtilities._gamedataPath));
        }
    }
    #endregion

    #region Player Data
    private void SavePlayerData(PlayerDataModel data)
    {
        if (data == null)
        {
            return;
        }

        if (data.Username != null) 
        {
            _player.Username = data.Username;
        }
        if (data.ExpValue >= 0)
        {
            _player.ExpValue = data.ExpValue;
        }

        var json = JsonConvert.SerializeObject(_player);
        _saveQueue.Enqueue(json);
    }

    private void LoadPlayerData()
    {
        string data = SaveUtilities.LoadData(GameSettingsUtilities._playerPath);

        if (data != null)
        {
            Debug.Log(data);

            _player = JsonConvert.DeserializeObject<PlayerDataModel>(data);

            Debug.Log(JsonConvert.SerializeObject(_player, Formatting.Indented));

            SaveEM.LoadPlayerDataResult(_player);
        }

        if (data == null)
        {
            SaveEM.LoadPlayerDataResult(null);
        }
    }
    #endregion
}
