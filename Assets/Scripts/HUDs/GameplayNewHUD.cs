using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayNewHUD : MonoBehaviour
{
    [SerializeField]
    private ScrollRect _gameScrollView;
    [SerializeField]
    private GameObject _tilePrefab;
    [SerializeField]
    private GameObject _blockerObject;

    private List<TileComponent> _tileList;

    private void Awake()
    {
        Assert.IsNotNull(_gameScrollView, $"[{gameObject.name}] ScrollView is not assigned.");
        Assert.IsNotNull(_tilePrefab, $"[{gameObject.name}] TilePrefab is not assigned.");
        Assert.IsNotNull(_blockerObject, $"[{gameObject.name}] BlockerObject is not assigned.");

        TileNewEM.OnResetTile += ResetScrollView;
        TileNewEM.OnGenerateTileComponents += GenerateTileComponents;
        TileNewEM.OnDisableTile += DisableTileAtIndex;
        TileNewEM.OnRemoveTilesInRow += RemoveTilesInRow;
        TileNewEM.OnDeselectTile += DeselectButton;
    }

    public void ResetScrollView()
    {
        for (int i = 0; i < _gameScrollView.content.childCount; i++)
        {
            Transform child = _gameScrollView.content.GetChild(i);
            Object.Destroy(child.gameObject);
        }
    }

    public void GenerateTileComponents(List<int> listValue)
    {
        _tileList = new List<TileComponent>();

        for (int i = 0; i < listValue.Count; i++)
        {
            GameObject tilePrefab = Instantiate(_tilePrefab, _gameScrollView.content);

            var tileComponent = tilePrefab.GetComponent<TileComponent>();
            tileComponent.SetIndex(i);
            tileComponent.SetValue(listValue[i]);
            tileComponent.GetButton().onClick.AddListener(() =>
            {
                TileNewEM.SelectTileIndex(tileComponent.GetIndex());
            });

            _tileList.Add(tileComponent);
        }
    }

    public void DisableTileAtIndex(int index)
    {
        if (_tileList != null && index >= 0 && index < _tileList.Count)
        {
            _tileList[index].DisableTile();
        }
        else
        {
            Debug.LogWarning($"[{gameObject.name}] Invalid index {index} for disabling tile.");
        }
    }

    public void SetBlockerActive(bool isActive)
    {
        _blockerObject.SetActive(isActive);
    }

    private void RemoveTilesInRow(int startTile)
    {
        int column = 10;

        for (int i = 0; i < column; i++)
        {
            Destroy(_tileList[startTile].gameObject);
            _tileList.RemoveAt(startTile);
        }
    }

    private void DeselectButton(int index)
    {
        _tileList[index].TurnToDeselectedButton();
    }
}
