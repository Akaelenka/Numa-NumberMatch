using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : IUnityAdsInitializationListener
{
    private string _gameId;

    public InitializeAds()
    {
#if UNITY_ANDROID
        _gameId = GameSettingsUtilities.AndroidGameId;
#elif UNITY_IOS
        _gameId = GameSettingsUtilities.IosGameId;
#else
        _gameId = GameSettingsUtilities.AndroidGameId;
#endif

        if (!   Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, GameSettingsUtilities.IsAdTesting, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("[InitializeAds] Ads Initialized");
        AdvertismentEM.SetInitAdvertismentDone();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("[InitializeAds] Ads Failed: " + message);
    }
}
