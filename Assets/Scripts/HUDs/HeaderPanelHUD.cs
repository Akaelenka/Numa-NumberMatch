using NumaModels;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class HeaderPanelHUD : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _usernameText;
    [SerializeField]
    private TMP_Text _levelText;
    [SerializeField]
    private ExpChartModel _expChart;
    [SerializeField]
    private ProgressionComponent _expProgression;

    private int _expValue;
    private int _expMaxValue;
    private int _expMinValue;
    private int _levelValue;

    private void Awake()
    {
        Assert.IsNotNull(_usernameText, $"[{gameObject.name}] UsernameText is not assigned.");
        Assert.IsNotNull(_levelText, $"[{gameObject.name}] LevelText is not assigned.");
        Assert.IsNotNull(_expChart, $"[{gameObject.name}] ExpChart is not assigned.");
        Assert.IsNotNull(_expProgression, $"[{gameObject.name}] ExpProgression is not assigned.");

        SaveEM.OnLoadPlayerDataResult += LoadProgression;

        PanelEM.OnTriggerToMainMenu += GainExp;
        AdvertisementEM.OnRewardedAdsCompleted += GainExp;
    }

    //private void ResetProgression()
    //{
    //    int maxProgression = 1; // TODO

    //    _expProgression.ResetProgression(maxProgression);
    //}

    private void GainExp()
    {
        var expBonus = GameSettingsUtilities.ExpGain;
        _expValue += expBonus;

        CalculateLevel();
        SaveData();
    }

    private void SaveData()
    {
        var data = new PlayerDataModel()
        {
            Username = _usernameText.text,
            ExpValue = _expValue,
        };
        SaveEM.SavePlayerData(data);
    }

    private void LoadProgression(PlayerDataModel data)
    {
        if (data == null)
        {
            return;
        }

        _usernameText.text = data.Username;
        _expValue = data.ExpValue;

        CalculateLevel();
    }

    private void CalculateLevel()
    {
        int level = 0;
        int minValue = 0;
        int maxValue = 0;

        foreach (var maxExp in _expChart.ExpList)
        {
            maxValue = maxExp;

            if (_expValue < maxValue)
            {
                break;
            }

            minValue = maxValue;
            level++;
        }

        _levelValue = level;
        _expMinValue = minValue;
        _expMaxValue = maxValue;

        SyncUI();
    }

    private void SyncUI()
    {
        _levelText.text = _levelValue.ToString();

        var progressionModel = new ProgressionComponentModel
        {
            MinValue = _expMinValue,
            MaxValue = _expMaxValue,
            CurrentValue = _expValue
        };
        _expProgression.SetProgression(progressionModel);
    }
}
