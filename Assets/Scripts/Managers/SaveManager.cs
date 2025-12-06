using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using NumaModels;

public class SaveManager : MonoBehaviour
{
    private GameDataModel _data;
    private Queue<GameDataModel> _saveQueue = new Queue<GameDataModel>();

    private bool _isSaving = false;

    private void Awake()
    {
        _data = new GameDataModel();

        PanelEM.OnStartGame += ResetData;

        SaveEM.OnSaveData += SaveData;
        SaveEM.OnLoadData += LoadData;
    }

    private void Update()
    {
        if (_saveQueue.Count > 0 && !_isSaving) 
        {
            _isSaving = true;

            var data = _saveQueue.Dequeue();
            var json = JsonConvert.SerializeObject(data);
            SaveUtilities.SaveData(json);

            Debug.Log("trying to save" + json);

            _isSaving = false;
        }
    }

    private void ResetData()
    {
        _data = new GameDataModel();
    }

    private void LoadData()
    {
        string data = SaveUtilities.LoadData();

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
        if (data.TileData != null)
        {
            _data.TileData = new List<int>();
            _data.TileData.AddRange(data.TileData);
        }

        _saveQueue.Enqueue(_data);
    }
}
