using NumaModels;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelHUD : MonoBehaviour
{
    [SerializeField]
    private Button _addButton;
    [SerializeField]
    private TMP_Text _addCountText;
    [SerializeField]
    private ProgressionComponent _progressionComponent;
    [SerializeField]
    private TMP_Text _currentScoreText;
    [SerializeField]
    private TMP_Text _targetScoreText;
    [SerializeField]
    private ScrollRect _gameScrollView;
    [SerializeField]
    private GameObject _tilePrefab;

    private List<TileComponent> _tileList;
    private List<int> _tileActiveList;
    private int[,] _tutoriaTile;

    private int _currentStep = 0;
    private int _targetScore = 14;
    private int _currentScore = 0;
    private int _nextAddedScore = 0;


    private void Awake()
    {
        // TODO: Assert
        _tileActiveList = new List<int>();
        _tutoriaTile = new int[,]        
        {
            {0, 8, 1},
            {4, 5, 1},
            {2, 9, 1},
            {-1, -1, 0}, // Add button
            {3, 12, 1},
            {1, 6, 5},
            {7, 10, 3},
            {11, 13, 2}
        };

        PanelEM.OnChangePanel += StartTutorial;

        _addButton.onClick.AddListener(AddButton);
        _addButton.interactable = false;

        SetProgression();
    }

    private void Update()
    {
        if (_tileActiveList.Count >= 2)
        {
            Debug.LogWarning("Active: " + _tileActiveList[0] + " " + _tileActiveList[1]);


            DisableTileAndSetNull(_tileActiveList[0]);
            DisableTileAndSetNull(_tileActiveList[1]);

            _currentScore += _nextAddedScore;
            SetProgression();

            _tileActiveList.Clear();

            EnableTwoTile();
        }

        if (_currentScore >= _targetScore) 
        {
            PanelEM.FinishTutorial(); // TODO: Create Congratulation
        }
    }

    private void GenerateNewTiles()
    {
        List<int> newTiles = new List<int>()
        {
            9, 2, 7, 1, 4, 4, 2, 6,
            9, 3
        };

        AddTileComponents(newTiles);
    }

    private void AddButton()
    {
        List<int> addedList = new List<int>()
        {
            6, 3, 9, 3
        };

        AddTileComponents(addedList);

        _addButton.interactable = false;
        _addCountText.text = 0.ToString();

        EnableTwoTile();
    }

    private void StartTutorial(EPanelType panel)
    {
        if (panel == EPanelType.Tutorial)
        {
            _tileList = new List<TileComponent>();

            GenerateNewTiles();

            EnableTwoTile();
        }
    }

    #region Tiles
    private void AddTileComponents(List<int> listValue)
    {
        for (int i = 0; i < listValue.Count; i++)
        {
            GameObject tilePrefab = Instantiate(_tilePrefab, _gameScrollView.content);

            var tileComponent = tilePrefab.GetComponent<TileComponent>();
            tileComponent.SetIndex(_tileList.Count);
            tileComponent.SetValue(listValue[i]);
            tileComponent.GetButton().onClick.AddListener(() =>
            {
                foreach (var tile in _tileList)
                {
                    tile.ToggleColorButton(false);
                }
                tileComponent.ToggleColorButton(true);

                _tileActiveList.Add(tileComponent.GetIndex());
            });

            if (tileComponent.GetValue() == 0)
            {
                tileComponent.DisableTile();
            }

            _tileList.Add(tileComponent);
        }
    }

    private void EnableTwoTile()
    {
        if (_currentStep >= _tutoriaTile.GetLength(0))
        {
            return;
        }

        DisableAllTiles();
        int indexA = _tutoriaTile[_currentStep, 0];
        int indexB = _tutoriaTile[_currentStep, 1];
        _nextAddedScore = _tutoriaTile[_currentStep, 2];

        if (indexA == -1 || indexB == -1)
        {
            _addButton.interactable = true;
        }
        else 
        {
            _tileList[indexA].SetActiveTile(true);
            _tileList[indexB].SetActiveTile(true);
        }

        _currentStep++;
    }

    private void DisableAllTiles()
    {
        for(int i = 0; i < _tileList.Count; i++)
        {
            _tileList[i].SetActiveTile(false);
        }
    }

    private void DisableTileAndSetNull(int index)
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

    private void RemoveTilesInRow(int startTile)
    {
        int column = GameSettingsUtilities.TotalColumn;

        for (int i = 0; i < column; i++)
        {
            Destroy(_tileList[startTile].gameObject);
            _tileList.RemoveAt(startTile);
        }
    }

    private void ResetIndex()
    {
        for (int i = 0; i < _tileList.Count; i++)
        {
            _tileList[i].SetIndex(i);
        }
    }
    #endregion
    #region Score
    private void SetProgression()
    {
        int targetScore = _targetScore;
        int currentScore = _currentScore;

        _targetScoreText.text = targetScore.ToString();
        _currentScoreText.text = currentScore.ToString();

        var progressionModel = new ProgressionComponentModel
        {
            MinValue = 0,
            MaxValue = targetScore,
            CurrentValue = currentScore
        };
        _progressionComponent.SetProgression(progressionModel);
    }
    #endregion
}
