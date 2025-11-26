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
    }

    private void ResetScore()
    {
        _currentTargetScore = GameSettingsUtilities.TotalScore;
        _currentScore = 0;

        _targetCoreText.text = _currentTargetScore.ToString();
        _scoreText.text = _currentScore.ToString();

        var progressionModel = new ProgressionComponentModel
        {
            MinValue = 0,
            MaxValue = _currentTargetScore,
            CurrentValue = 0
        };
        _progressionComponent.SetProgression(progressionModel);
    }

    private void AddScore(int value)
    {
        _currentScore += value;
        _scoreText.text = _currentScore.ToString();

        _progressionComponent.UpdateProgression(_currentScore);

        CheckScore();
    }

    private void CheckScore()
    {
        if (_currentScore >= _currentTargetScore)
        {
            ScoreEM.ReachTargetScore();
        }
    }
}
