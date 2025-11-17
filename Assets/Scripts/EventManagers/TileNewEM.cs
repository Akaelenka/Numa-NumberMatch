using System;
using System.Collections.Generic;

public class TileNewEM
{
    public static event Action OnResetTile;
    public static event Action<List<int>> OnGenerateTileComponents;
    public static event Action<List<int>> OnAddTileComponents;
    public static event Action<int> OnSelectedTileIndex;
    public static event Action OnTileMatched;
    public static event Action<int> OnDisableTile;
    public static event Action OnFinishCheckMatchedTile;
    public static event Action<int> OnRemoveTilesInRow;
    public static event Action<int> OnDeselectTile;

    public static event Action<bool> OnSetBlockerActive;
    public static event Action<int> OnCallAddNewTiles;

    public static event Action OnResetTileIndex;

    public static void ResetTile()
    {
        OnResetTile?.Invoke();
    }

    public static void GenerateTileComponents(List<int> valueList)
    {
        OnGenerateTileComponents?.Invoke(valueList);
    }

    public static void AddTileComponents(List<int> valueList)
    {
        OnAddTileComponents?.Invoke(valueList);
    }

    public static void SelectTileIndex(int index)
    {
        OnSelectedTileIndex?.Invoke(index);
    }

    public static void GetTileMatched()
    {
        OnTileMatched?.Invoke();
    }

    public static void DisableTile(int index)
    {
        OnDisableTile?.Invoke(index);
    }

    public static void FinishCheckMatchedTile()
    {
        OnFinishCheckMatchedTile?.Invoke();
    }

    public static void RemoveTilesInRow(int index)
    {
        OnRemoveTilesInRow?.Invoke(index);
    }

    public static void DeselectTile(int index)
    {
        OnDeselectTile?.Invoke(index);
    }

    public static void SetBlockerActive(bool isActive)
    {
        OnSetBlockerActive?.Invoke(isActive);
    }

    public static void ResetTileIndex()
    {
        OnResetTileIndex?.Invoke();
    }

    public static void CallAddNewTiles(int value)
    {
        OnCallAddNewTiles?.Invoke(value);
    }
}
