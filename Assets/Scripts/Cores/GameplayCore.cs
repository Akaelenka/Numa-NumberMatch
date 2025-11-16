using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameplayCore
{
    public List<int> ListValue;

    private int _prevousTileValue;
    private int _activeTileValue;
    private int _prevousTileIndex;
    private int _activeTileIndex;

    public GameplayCore() 
    {
        TileNewEM.OnSelecteTileIndex += OnSelectTileIndex;
    }

    public void ResetTiles()
    {
        ResetActiveTile();

        TileNewEM.ResetTile();
    }

    public void GenerateTiles(int totalTiles)
    {
        ListValue = new List<int>();

        // Init to random half of total tiles
        System.Random rnd = new System.Random();
        for (int i = 0; i < totalTiles/2; i++)
        {
            int value = rnd.Next(1, 10);
            ListValue.Add(value);
        }

        // Duplicate and invert values to create pairs
        for (int i = 0;i < totalTiles/2; i++)
        {
            int value = rnd.Next(0, 2);
            ListValue.Add(value == 0 ? ListValue[i] : 10 - ListValue[i]);
        }

        // Shuffle the list
        ListValue = ListValue.OrderBy(x => rnd.Next()).ToList();

        TileNewEM.GenerateTileComponents(ListValue);
    }

    public void CheckMatchedTiles()
    {
        int columns = 10; // TODO: Make this dynamic based on the table configuration

        int prevTileIndex = _prevousTileIndex;
        int currTileIndex = _activeTileIndex;
        int diff = Mathf.Abs(prevTileIndex - currTileIndex);

        // Determine the step (direction)
        int step = 0;

        // Horizontal (same row)
        if (TableUtilities.GetRow(currTileIndex, columns) == TableUtilities.GetRow(prevTileIndex, columns))
        {
            step = (prevTileIndex > currTileIndex) ? 1 : -1;
        }
        // Vertical (same column)
        else if (TableUtilities.GetCol(currTileIndex, columns) == TableUtilities.GetCol(prevTileIndex, columns))
        {
            step = (prevTileIndex > currTileIndex) ? columns : -columns;
        }
        // Diagonal (Down Right)
        else if (Mathf.Abs(diff) % (columns + 1) == 0)
        {
            step = (prevTileIndex > currTileIndex) ? (columns + 1) : -(columns + 1);
        }
        // Diagonal (Down Left)
        else if (Mathf.Abs(diff) % (columns - 1) == 0)
        {
            step = (prevTileIndex > currTileIndex) ? (columns - 1) : -(columns - 1);
        }
        // Not a straight line
        else
        {
            TileNewEM.FinishCheckMatchedTile();
            return;
        }

        // Walk from a to b, but skip the endpoints
        int current = currTileIndex + step;
        while (current != prevTileIndex)
        {
            if (ListValue[current] != 0)   // occupied tile found
            {
                TileNewEM.FinishCheckMatchedTile();
                return;
            }

            current += step;
        }

        ListValue[_prevousTileIndex] = 0;
        ListValue[_activeTileIndex] = 0;

        TileNewEM.DisableTile(_prevousTileIndex);
        TileNewEM.DisableTile(_activeTileIndex);

        ResetActiveTile();

        TileNewEM.FinishCheckMatchedTile();
    }

    private void ResetActiveTile()
    {
        _activeTileIndex = -1;
        _activeTileValue = 0;
        _prevousTileIndex = -1;
        _prevousTileValue = 0;
    }

    #region EventHandlers
    private void OnSelectTileIndex(int index)
    {
        if (_activeTileValue != 0)
        {
            _prevousTileValue = _activeTileValue;
            _prevousTileIndex = _activeTileIndex;
        }

        _activeTileIndex = index;
        _activeTileValue = ListValue[index];

        Debug.Log($"[{this.GetType().Name}] Active tile index: {_activeTileIndex} with value: {_activeTileValue}.");
        Debug.Log($"[{this.GetType().Name}] Previous tile index: {_prevousTileIndex} with value: {_prevousTileValue}.");

        int combinedValue = _prevousTileValue + _activeTileValue;
        if (_prevousTileValue == _activeTileValue || combinedValue == 10)
        {
            Debug.Log("Tile is matched.");
            TileNewEM.GetTileMatched();
        }
    }
    #endregion
}
