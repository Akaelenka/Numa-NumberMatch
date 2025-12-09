using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds
{
    private string _adUnitId;

    public BannerAds()
    {
#if UNITY_ANDROID
        _adUnitId = GameSettingsUtilities.AndroidAdBannerId;
#elif UNITY_IOS
        _adUnitId = GameSettingsUtilities.IosAdBannerId;
#else
        _adUnitId = GameSettingsUtilities.AndroidAdBannerId;
#endif

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    public void LoadBannerAd()
    {
        BannerLoadOptions options = new BannerLoadOptions()
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError 
        };

        Advertisement.Banner.Load(_adUnitId, options);
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions()
        {
            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden
        };

        Advertisement.Banner.Show(_adUnitId, options);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    #region Show Callbacks
    private void BannerHidden()
    {
    }

    private void BannerClicked()
    {
    }

    private void BannerShown()
    {
    }
    #endregion

    #region Load Callbacks
    private void BannerLoadedError(string message)
    {
    }

    private void BannerLoaded()
    {
    }
    #endregion
}
