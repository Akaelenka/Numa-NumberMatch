using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode] // TODO: For testing purposes only, remove later
public class GameplayHUD : MonoBehaviour
{
    [SerializeField]
    private ScrollRect _gameScrollView;

    //[SerializeField] // TODO: For testing purposes only, remove later
    private List<TileComponent> _tileList;
    private int _previousSelectedTileIndex;
    private int _selectedTileIndex;

    //// TODO: For testing purposes only, remove later
    //private void Update()
    //{
    //    AssignTileToList();
    //}

    private void Awake()
    {
        GameplayEM.OnStartGame += AssignTileToList;

        TileEM.OnAssignNewTileList += AssingTileList;
        TileEM.OnSelecteTileIndex += AssignActiveTile;
        TileEM.OnRemoveTilesInColumn += RemoveTilesInColumn;
        TileEM.OnMatchesTileFound += DisableMatchesTile;
        TileEM.OnResetValue += ResetTileIndex;
    }

    private void AssingTileList(List<int> tileValues)
    {
        // Check if the ScrollView reference is assigned
        if (_gameScrollView == null)
        {
            Debug.LogError($"[{gameObject.name}] ScrollView is not assigned.");
            return;
        }
        if (_gameScrollView.content == null)
        {
            Debug.LogError($"[{gameObject.name}] ScrollView content container is missing.");
            return;
        }

        // Assign values to each TileComponent in the ScrollView content container
        for (int i = 0; i < _gameScrollView.content.childCount; i++)
        {
            Transform child = _gameScrollView.content.GetChild(i);
            TileComponent tileComponent = child.GetComponent<TileComponent>();
            if (tileComponent != null && i < tileValues.Count)
            {
                tileComponent.SetValue(tileValues[i]);
            }
        }

        GameplayEM.StartGame();
    }

    private void AssignTileToList()
    {
        // Check if the ScrollView reference is assigned
        if (_gameScrollView == null)
        {
            Debug.LogError($"[{gameObject.name}] ScrollView is not assigned.");
            return;
        }
        if (_gameScrollView.content == null)
        {
            Debug.LogError($"[{gameObject.name}] ScrollView content container is missing.");
            return;
        }

        // Get all TileComponent in the ScrollView content container
        _tileList = new List<TileComponent>();
        for (int i = 0; i < _gameScrollView.content.childCount; i++)
        {
            Transform child = _gameScrollView.content.GetChild(i);
            TileComponent tileComponent = child.GetComponent<TileComponent>();
            if (tileComponent != null)
            {
                _tileList.Add(tileComponent);
                tileComponent.SetIndex(i);
            }
        }
    }

    //private void CheckTilesInColumn()
    //{

    //}

    private void AssignActiveTile(int index)
    {
        if (_selectedTileIndex != 0)
        {
            _previousSelectedTileIndex = _selectedTileIndex;
        }
        _selectedTileIndex = index;

        TileEM.CheckMatchesTile();
    }

    private void DisableMatchesTile()
    {
        int columns = 10; // TODO: Make this dynamic based on the table configuration

        Debug.Log($"[{gameObject.name}] Tiles are in the same direction.");

        int prevTileIndex = _previousSelectedTileIndex;
        int currTileIndex = _selectedTileIndex;
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
            return;
        }

        // Walk from a → b, but skip the endpoints
        int current = currTileIndex + step;
        while (current != prevTileIndex)
        {
            if (_tileList[current].IsEnable())   // occupied tile found
            {
                return;
            }

            current += step;
        }

        _tileList[_previousSelectedTileIndex].DisableTile();
        _tileList[_selectedTileIndex].DisableTile();

        TileEM.ResetValue();


        //if (TableUtilities.IsHorizontal(_previousSelectedTileIndex, _selectedTileIndex, columns))
        //{

        //}
        //else
        //{
        //    Debug.Log($"[{gameObject.name}] Tiles are NOT in the same direction.");
        //}

    }

    private void ResetTileIndex()
    {
        _previousSelectedTileIndex = 0;
        _selectedTileIndex = 0;
    }

    private void RemoveTilesInColumn(int startTile)
    {
        int blockIteration = 10;

        for (int i = 0; i < blockIteration; i++)
        {
            Destroy(_tileList[startTile].gameObject);
            _tileList.RemoveAt(startTile);
        }
    }
}
