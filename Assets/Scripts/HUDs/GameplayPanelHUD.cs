using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameplayPanelHUD : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _limitAddTilesText;
    [SerializeField]
    private Button _addTilesButton;

    private const int LimitHardcode = 5; // TODO: change it later with proper
    private int _limitAddTiles; 

    private void Awake()
    {
        Assert.IsNotNull(_limitAddTilesText, $"[{gameObject.name}] LimitAddTilesText is not assigned.");
        Assert.IsNotNull(_addTilesButton, $"[{gameObject.name}] AddTilesButton is not assigned.");

        TileNewEM.OnResetTile += ResetLimit;
        TileNewEM.OnCallAddNewTiles += ReduceLimit;
    }


    private void ResetLimit()
    {
        _limitAddTiles = LimitHardcode;
        _limitAddTilesText.text = _limitAddTiles.ToString();
        
        CheckLimit();
    }

    private void ReduceLimit(int value)
    {
        _limitAddTiles--;
        _limitAddTilesText.text = _limitAddTiles.ToString();

        CheckLimit();
    }

    private void CheckLimit()
    {
        if (_limitAddTiles == 0)
        {
            _addTilesButton.interactable = false;
        }
        else
        {
            _addTilesButton.interactable = true;
        }
    }
}
