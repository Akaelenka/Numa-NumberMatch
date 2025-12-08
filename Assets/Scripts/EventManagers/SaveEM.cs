using NumaModels;
using System;

public class SaveEM
{
    public static event Action<GameDataModel> OnSaveData;
    public static event Action OnLoadData;
    public static event Action<GameDataModel> OnLoadDataResult;
    public static event Action<bool> OnIsDataExist;

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
}
