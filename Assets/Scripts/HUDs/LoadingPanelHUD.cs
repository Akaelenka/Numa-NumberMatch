using UnityEngine.Assertions;
using UnityEngine;
using NumaModels;

public class LoadingPanelHUD : MonoBehaviour
{
    [SerializeField]
    private ProgressionComponent _loadingProgression;

    private int _maxLoadingValue = GameSettingsUtilities.MaxLoading;
    private bool _adsReady = false;
    private bool _playerDataReady = false;
    private bool _playerDataAvailable = false;

    private void Awake()
    {
        Assert.IsNotNull(_loadingProgression, $"[{gameObject.name}] LoadingProgression is not assigned.");

        LoadingEM.OnResetProgression += ResetProgression;
        LoadingEM.OnUpdateProgression += UpdateProgression;

        AdvertisementEM.OnInitAdvertismentDone += SetAdReady;

        SaveEM.OnLoadPlayerDataResult += SetPlayerDataReady;
    }

    private void ResetProgression()
    {
        _loadingProgression.ResetProgression(_maxLoadingValue);
    }

    private void UpdateProgression(int value)
    {
        _loadingProgression.UpdateProgression(value);

        if (value >= _maxLoadingValue && _adsReady && _playerDataReady) 
        {
            if (_playerDataAvailable)
            {
                LoadingEM.LoadingComplete();
            }
            else
            {
                PanelEM.StartIntro();
            }
        }
    }

    private void SetAdReady()
    {
        _adsReady = true;
    }

    private void SetPlayerDataReady(PlayerDataModel data)
    {
        _playerDataReady = true;

        if (data != null) 
        {
            _playerDataAvailable = true;
        }
    }
}
