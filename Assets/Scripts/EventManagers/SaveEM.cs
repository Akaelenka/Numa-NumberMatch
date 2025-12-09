using NumaModels;
using System;

public class SaveEM
{
    public static event Action<GameDataModel> OnSaveData;
    public static event Action OnLoadData;
    public static event Action<GameDataModel> OnLoadDataResult;
    public static event Action<bool> OnIsDataExist;

    public static event Action<PlayerDataModel> OnSavePlayerData;
    public static event Action OnLoadPlayerData; // TODO: check if it's used or not
    public static event Action<PlayerDataModel> OnLoadPlayerDataResult;
    public static event Action<bool> OnIsPlayerDataExist;

    public static void SaveData(GameDataModel data)
    {
        OnSaveData?.Invoke(data);
    }

    public static void LoadData() 
    {
        OnLoadData?.Invoke();
    }

    public static void LoadDataResult(GameDataModel data)
    {
        OnLoadDataResult?.Invoke(data);
    }

    public static void IsDataExist(bool isExist)
    {
        OnIsDataExist?.Invoke(isExist);
    }

    public static void SavePlayerData(PlayerDataModel data)
    {
        OnSavePlayerData?.Invoke(data);
    }

    public static void LoadPlayerData()
    {
        OnLoadPlayerData?.Invoke();
    }

    public static void LoadPlayerDataResult(PlayerDataModel data)
    {
        OnLoadPlayerDataResult?.Invoke(data);
    }

    public static void IsPlayerDataExist(bool isExist)
    {
        OnIsPlayerDataExist?.Invoke(isExist);
    }
}
