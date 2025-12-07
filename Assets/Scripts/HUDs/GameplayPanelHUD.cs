using NumaModels;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameplayPanelHUD : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _limitAddTilesText;
    [SerializeField]
    private Button _addTilesButton; // TODO: move the gameplay new hud for add tiles button here
    [SerializeField]
    private Button _backButton;

    private const int LimitHardcode = 5; // TODO: change it later with proper
    private int _limitAddTiles; 

    private void Awake()
    {
        Assert.IsNotNull(_limitAddTilesText, $"[{gameObject.name}] LimitAddTilesText is not assigned.");
        Assert.IsNotNull(_addTilesButton, $"[{gameObject.name}] AddTilesButton is not assigned.");
        Assert.IsNotNull(_backButton, $"[{gameObject.name}] BackButton is not assigned.");

        TileNewEM.OnResetTile += ResetLimit;
        TileNewEM.OnCallAddNewTiles += ReduceLimit;

        SaveEM.OnLoadDataResult += LoadLimit;

        _backButton.onClick.AddListener(BackToMainMenu);
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
        UpdateLimit();
    }

    private void UpdateLimit()
    {
        _limitAddTilesText.text = _limitAddTiles.ToString();

        var data = new GameDataModel();
        data.HelpCount = _limitAddTiles;
        SaveEM.SaveData(data);

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

    private void LoadLimit(GameDataModel data)
    {
        _limitAddTiles = data.HelpCount;
        _limitAddTilesText.text = data.HelpCount.ToString();

        CheckLimit();
    }

    private void BackToMainMenu()
    {
        PanelEM.QuitGame();
    }
}
