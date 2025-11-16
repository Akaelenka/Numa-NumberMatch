using System;
using System.Collections.Generic;

public class TileEM
{
    public static event Action<List<int>> OnAssignNewTileList;
    public static event Action<int> OnRemoveTilesInColumn;
    public static event Action<int> OnSelecteTileValue;
    public static event Action<int> OnSelecteTileIndex;
    public static event Action OnCheckMatchesTile;
    public static event Action OnMatchesTileFound;
    public static event Action OnResetValue;

    public static void AssignNewTileList(List<int> tileValues)
    {
        OnAssignNewTileList?.Invoke(tileValues);
    }

    public static void RemoveTilesInColumn(int startTile)
    {
        OnRemoveTilesInColumn?.Invoke(startTile);
    }

    public static void SelectTileValue(int value)
    {
        OnSelecteTileValue?.Invoke(value);
    }

    public static void SelectTileIndex(int value)
    {
        OnSelecteTileIndex?.Invoke(value);
    }

    public static void CheckMatchesTile()
    {
        OnCheckMatchesTile?.Invoke();
    }

    public static void MatchesTileFound()
    {
        OnMatchesTileFound?.Invoke();
    }

    public static void ResetValue()
    {
        OnResetValue?.Invoke();
    }
}
