using NumaModels;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameplayCore
{
    public bool IsReachedTargetScore = false;
    public bool IsBackToMainMenu = false;

    private int _prevousTileValue;
    private int _activeTileValue;
    private int _prevousTileIndex;
    private int _activeTileIndex;

    private List<int> _listDestroyQueue = new List<int>();
    private List<int> _listValue;

    public EGameSelection GameSelection;

    public GameplayCore()
    {
        TileNewEM.OnSelectedTileIndex += OnSelectTileIndex;
        TileNewEM.OnRemoveTilesInRow += OnRemoveTilesInRow;
        TileNewEM.OnCallAddNewTiles += AddNewTiles;

        ScoreEM.OnReachTargetScore += OnReachTargetScore;

        SaveEM.OnLoadDataResult += GenerateTiles;
    }

    public void ResetTiles()
    {
        IsReachedTargetScore = false;
        ResetActiveTile();

        bool isSaving = GameSelection == EGameSelection.Start;

        TileNewEM.ResetTile();
        ScoreEM.ResetScore(isSaving);
    }

    public void GenerateTiles(int totalTiles)
    {
        _listValue = new List<int>();
        _listValue.AddRange(CreateAndShuffleNewTiles(totalTiles));

        TileNewEM.GenerateTileComponents(_listValue);

        SaveData();
    }

    public void GenerateTiles(GameDataModel data)
    {
        _listValue = new List<int>();
        if (data.TileData != null) 
        {
            _listValue.AddRange(data.TileData);

            TileNewEM.GenerateTileComponents(_listValue);
        }
        else
        {
            GenerateTiles(GameSettingsUtilities.TotalGeneratedTile);
        }
    }

    public void AddNewTiles(int totalTiles)
    {
        List<int> addedList = new List<int>();
        if (GameSettingsUtilities.IsTesting) // TODO: Change using #
        {
            addedList.AddRange(GameSettingsUtilities.GetTestValue());
        }
        else
        {
            addedList.AddRange(CreateAndShuffleNewTiles(totalTiles));
        }

        _listValue.AddRange(addedList);

        TileNewEM.AddTileComponents(addedList);
    }

    private List<int> CreateAndShuffleNewTiles(int totalTiles)
    {
        List<int> newTiles = new List<int>();


        // TODO Move somewhere

        // Easy
        //// Init to random half of total tiles
        //System.Random rnd = new System.Random();
        //for (int i = 0; i < totalTiles / 2; i++)
        //{
        //    int value = rnd.Next(1, 10);
        //    newTiles.Add(value);
        //}

        //// Duplicate and invert values to create pairs
        //for (int i = 0; i < totalTiles / 2; i++)
        //{
        //    int value = rnd.Next(0, 2);
        //    newTiles.Add(value == 0 ? newTiles[i] : 10 - newTiles[i]);
        //}

        // Hard
        // Init to random quartz of total tiles
        System.Random rnd = new System.Random();
        for (int i = 0; i < totalTiles / 4; i++)
        {
            int value = rnd.Next(1, 10);
            newTiles.Add(value);
        }

        // Duplicate and invert values to create pairs
        for (int i = 0; i < totalTiles / 4; i++)
        {
            int value = rnd.Next(0, 2);
            newTiles.Add(value == 0 ? newTiles[i] : 10 - newTiles[i]);
        }

        // Random quartz
        for (int i = 0; i < totalTiles / 4; i++)
        {
            int value = newTiles[i];
            value = value > 9 ? 1 : value;

            newTiles.Add(value);
        }

        // Random quartz
        for (int i = 0; i < totalTiles / 4; i++)
        {
            int value = rnd.Next(1, 10);
            newTiles.Add(value);
        }

        // Shuffle the list
        newTiles = newTiles.OrderBy(x => rnd.Next()).ToList();

        return newTiles;
    }

    public void CheckMatchedTiles()
    {
        int columns = GameSettingsUtilities.TotalColumn;

        int prevTileIndex = _prevousTileIndex;
        int currTileIndex = _activeTileIndex;
        int diff = Mathf.Abs(prevTileIndex - currTileIndex);

        // Determine the step (direction)
        int step = 0;

        // Horizontal (same row)
        if (TableHelper.GetRow(currTileIndex, columns) == TableHelper.GetRow(prevTileIndex, columns))
        {
            step = (prevTileIndex > currTileIndex) ? 1 : -1;
        }
        // Vertical (same column)
        else if (TableHelper.GetCol(currTileIndex, columns) == TableHelper.GetCol(prevTileIndex, columns))
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
        // Find different row
        else if (Mathf.Abs(TableHelper.GetRow(currTileIndex, columns) - TableHelper.GetRow(prevTileIndex, columns)) == 1)
        {
            step = (prevTileIndex > currTileIndex) ? 1 : -1;
        }
        // Not a straight line
        else
        {
            TileNewEM.FinishCheckMatchedTile();
            return;
        }

        // Walk from a to b, but skip the endpoints
        int current = currTileIndex + step;
        int score = 1;
        while (current != prevTileIndex)
        {
            if (_listValue[current] != 0)   // occupied tile found
            {
                TileNewEM.FinishCheckMatchedTile();
                return;
            }

            current += step;
            score++;
        }

        _listValue[_prevousTileIndex] = 0;
        _listValue[_activeTileIndex] = 0;

        TileNewEM.DisableTile(_prevousTileIndex);
        TileNewEM.DisableTile(_activeTileIndex);
        ScoreEM.AddScore(score);

        CheckAndRemoveRow(_prevousTileIndex);
        CheckAndRemoveRow(_activeTileIndex);
        ResetActiveTile();  

        if (_listDestroyQueue.Count > 0)
        {

            _listDestroyQueue = _listDestroyQueue.Distinct().OrderByDescending(x => x).ToList();
            foreach (int startTile in _listDestroyQueue)
            {
                TileNewEM.RemoveTilesInRow(startTile);
            }
            _listDestroyQueue.Clear();
        }

        SaveData();
        TileNewEM.FinishCheckMatchedTile();
    }

    private void ResetActiveTile()
    {
        _activeTileIndex = -1;
        _activeTileValue = 0;
        _prevousTileIndex = -1;
        _prevousTileValue = 0;
    }

    private void CheckAndRemoveRow(int startTile)
    {
        int columns = GameSettingsUtilities.TotalColumn;
        int colIndex = TableHelper.GetRow(startTile, columns);

        int startColIndex = colIndex * columns;

        bool isColumnFull = true;
        for (int i = 0; i < columns; i++)
        {
            Debug.Log($"Checking tile at index: {i + startColIndex} with value: {_listValue[i + startColIndex]}.");

            if (_listValue[i + startColIndex] != 0)
            {
                isColumnFull = false;
                break;
            }
        }

        if (isColumnFull)
        {
            _listDestroyQueue.Add(startColIndex);
        }
    }

    private void SaveData()
    {
        var data = new GameDataModel();
        data.TileData = new List<int>();
        data.TileData.AddRange(_listValue);

        SaveEM.SaveData(data);
    }

    #region EventHandlers
    private void OnSelectTileIndex(int index)
    {
        if (_activeTileIndex == index)
        {
            TileNewEM.DeselectTile(index);
            ResetActiveTile();
            return; 
        }

        if (_activeTileValue != 0)
        {
            _prevousTileValue = _activeTileValue;
            _prevousTileIndex = _activeTileIndex;
        }

        _activeTileIndex = index;
        _activeTileValue = _listValue[index];

        Debug.Log($"[{this.GetType().Name}] Active tile index: {_activeTileIndex} with value: {_activeTileValue}.");
        Debug.Log($"[{this.GetType().Name}] Previous tile index: {_prevousTileIndex} with value: {_prevousTileValue}.");

        int combinedValue = _prevousTileValue + _activeTileValue;
        if (_prevousTileValue == _activeTileValue || combinedValue == 10)
        {
            Debug.Log("Tile is matched.");
            TileNewEM.GetTileMatched();
        }
    }

    private void OnRemoveTilesInRow(int startTile)
    {
        int column = GameSettingsUtilities.TotalColumn;
        int removeCount = Mathf.Min(column, _listValue.Count - startTile);

        Debug.Log($"Before removal: count {_listValue.Count}, removing {removeCount} tiles starting at {startTile}.");

        _listValue.RemoveRange(startTile, removeCount);

        Debug.Log($"After removal: count {_listValue.Count}.");

        ScoreEM.AddScore(GameSettingsUtilities.TotalStrikeScore);
    }

    private void OnReachTargetScore()
    {
        IsReachedTargetScore = true;
    }
    #endregion
}
