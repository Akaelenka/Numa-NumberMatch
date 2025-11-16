using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private int _prevousActiveTileValue;
    private int _activeTileValue;

    private int _tileMathcesCheck;

    private void Awake()
    {
        GameplayEM.OnPrepareGame += AssignTilesValue;
        TileEM.OnSelecteTileValue += AssignActiveTile;
        TileEM.OnCheckMatchesTile += CheckMathcesTile;
        TileEM.OnResetValue += ResetValue;
    }

    private void Start()
    {
        // TODO: Put this call in proper place
        GameplayEM.PrepareGame();
    }

    private void AssignTilesValue()
    {
        // TODO: Implement correct logic to assign tile values at the start of the game
        List<int> tileValueList = new List<int> 
        { 
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 2, 1, 2, 7, 2, 2, 2, 2, 2,
            3, 4, 3, 3, 3, 3, 3, 3, 3, 3,
            4, 4, 4, 4, 4, 4, 6, 4, 4, 4,
            5, 5, 5, 6, 5, 5, 5, 5, 5, 5
        }; // Example values

        TileEM.AssignNewTileList(tileValueList);
    }

    private void AssignActiveTile(int value)
    {
        if (_activeTileValue != 0)
        {
            _prevousActiveTileValue = _activeTileValue;
        }

        _activeTileValue = value;
        Debug.Log($"[{gameObject.name}] Active tile index value: {_activeTileValue} && {_prevousActiveTileValue}.");

        TileEM.CheckMatchesTile();
    }

    private void CheckMathcesTile()
    { 
        //Debug.Log(_tileMathcesCheck);

        _tileMathcesCheck++;
        if (_tileMathcesCheck < 2)
        {
            return;
        }

        int combinedValue = _prevousActiveTileValue + _activeTileValue;
        if (_prevousActiveTileValue == _activeTileValue || combinedValue == 10)
        {
            TileEM.MatchesTileFound();
            //Debug.Log($"[{gameObject.name}] Match found.");
        }

        _tileMathcesCheck = 0;
    }

    private void ResetValue()
    {
        _prevousActiveTileValue = 0;
        _activeTileValue = 0;
    }
}
