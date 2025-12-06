using UnityEngine;
using TMPro;
using NumaModels;
using UnityEngine.Assertions;

public class ScoreHUD : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _targetCoreText;
    [SerializeField]
    private ProgressionComponent _progressionComponent;

    private int _currentTargetScore = 0;
    private int _currentScore = 0;

    private void Awake()
    {
        Assert.IsNotNull(_scoreText, $"[{gameObject.name}] ScoreText is not assigned.");
        Assert.IsNotNull(_progressionComponent, $"[{gameObject.name}] ProgressionComponent is not assigned.");
        Assert.IsNotNull(_targetCoreText, $"[{gameObject.name}] TargetCoreText is not assigned.");

        ScoreEM.OnResetScore += ResetScore;
        ScoreEM.OnAddScore += AddScore;

        SaveEM.OnLoadDataResult += LoadScore;
    }

    private void ResetScore(bool isSaving)
    {
        _currentTargetScore = GameSettingsUtilities.TotalScore;
        _currentScore = 0;

        SetProgression();

        if (isSaving)
        {
            SaveScore();
        }
    }

    private void AddScore(int value)
    {
        _currentScore += value;
        _scoreText.text = _currentScore.ToString();

        _progressionComponent.UpdateProgression(_currentScore);

        SaveScore();
        CheckScore();
    }

    private void CheckScore()
    {
        if (_currentScore >= _currentTargetScore)
        {
            ScoreEM.ReachTargetScore();
        }
    }

    private void SaveScore()
    {
        var data = new GameDataModel();
        data.CurrentScore = _currentScore;
        data.TargetScore = _currentTargetScore;

        SaveEM.SaveData(data);
    }

    private void LoadScore(GameDataModel data)
    {
        _currentTargetScore = data.TargetScore;
        _currentScore = data.CurrentScore;

        SetProgression();
    }

    private void SetProgression()
    {
        int targetScore = _currentTargetScore;
        int currentScore = _currentScore;

        _targetCoreText.text = targetScore.ToString();
        _scoreText.text = currentScore.ToString();

        var progressionModel = new ProgressionComponentModel
        {
            MinValue = 0,
            MaxValue = targetScore,
            CurrentValue = currentScore
        };
        _progressionComponent.SetProgression(progressionModel);
    }
}
