using NumaModels;
using UnityEngine.Assertions;
using UnityEngine;

public class LoadingPanelHUD : MonoBehaviour
{
    [SerializeField]
    private ProgressionComponent _loadingProgression;

    private int _maxLoadingValue = GameSettingsUtilities.MaxLoading;
    private bool _adsReady = false;

    private void Awake()
    {
        Assert.IsNotNull(_loadingProgression, $"[{gameObject.name}] LoadingProgression is not assigned.");

        LoadingEM.OnResetProgression += ResetProgression;
        LoadingEM.OnUpdateProgression += UpdateProgression;

        AdvertismentEM.OnInitAdvertismentDone += SetAdReady;
    }

    private void ResetProgression()
    {
        ProgressionComponentModel progressionComponent = new ProgressionComponentModel
        {
            CurrentValue = 0,
            MinValue = 0,
            MaxValue = _maxLoadingValue
        };

        _loadingProgression.SetProgression(progressionComponent);
    }

    private void UpdateProgression(int value)
    {
        _loadingProgression.UpdateProgression(value);

        if (value >= _maxLoadingValue && _adsReady) 
        {
            LoadingEM.LoadingComplete();
        }
    }

    private void SetAdReady()
    {
        _adsReady = true;
    }
}
