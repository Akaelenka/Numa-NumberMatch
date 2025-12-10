using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string _adUnitId;

    public event Action OnRewardedAdsCompleted;

    public RewardedAds()
    {
#if UNITY_ANDROID
        _adUnitId = GameSettingsUtilities.AndroidAdRewardedId;
#elif UNITY_IOS
        _adUnitId = GameSettingsUtilities.IosAdRewardedId;
#else
        _adUnitId = GameSettingsUtilities.AndroidAdRewardedId;
#endif
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(_adUnitId, this);
        LoadRewardedAd();
    }

    #region Load Callbacks
    public void OnUnityAdsAdLoaded(string placementId)
    {
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }
    #endregion

    #region Show Callbacks
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _adUnitId && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)) 
        {
            OnRewardedAdsCompleted?.Invoke();
            Debug.Log("Completed");
        }
    }
    #endregion
}
