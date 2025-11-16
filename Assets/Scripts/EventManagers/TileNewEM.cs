using System;
using System.Collections.Generic;

public class TileNewEM
{
    public static event Action OnResetTile;
    public static event Action<List<int>> OnGenerateTileComponents;
    public static event Action<int> OnSelecteTileIndex;
    public static event Action OnTileMatched;
    public static event Action<int> OnDisableTile;
    public static event Action OnFinishCheckMatchedTile;

    public static event Action<bool> OnSetBlockerActive;

    public static void ResetTile()
    {
        OnResetTile?.Invoke();
    }

    public static void GenerateTileComponents(List<int> tileComponents)
    {
        OnGenerateTileComponents?.Invoke(tileComponents);
    }

    public static void SelectTileIndex(int index)
    {
        OnSelecteTileIndex?.Invoke(index);
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

    public static void SetBlockerActive(bool isActive)
    {
        OnSetBlockerActive?.Invoke(isActive);
    }
}
