using NumaModels;
using NUnit.Framework;
using UnityEngine;

public class LoadingPanelHUD : MonoBehaviour
{
    [SerializeField]
    private ProgressionComponent _loadingProgression;

    private int MaxLoadingValue = 1000;

    private void Awake()
    {
        Assert.IsNotNull(_loadingProgression, $"[{gameObject.name}] LoadingProgression is not assigned.");

        LoadingEM.OnResetProgression += ResetProgression;
        LoadingEM.OnUpdateProgression += UpdateProgression;
    }

    private void ResetProgression()
    {
        ProgressionComponentModel progressionComponent = new ProgressionComponentModel
        {
            CurrentValue = 0,
            MinValue = 0,
            MaxValue = MaxLoadingValue
        };

        _loadingProgression.SetProgression(progressionComponent);
    }

    private void UpdateProgression(int value)
    {
        _loadingProgression.UpdateProgression(value);

        if (value >= MaxLoadingValue) 
        {
            LoadingEM.LoadingComplete();
        }
    }
}
