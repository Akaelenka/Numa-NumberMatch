using System;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    private InitializeAds _initAds;
    private BannerAds _bannerAds;
    private RewardedAds _rewardedAds;

    private void Awake()
    {
        _initAds = new InitializeAds();
        _bannerAds = new BannerAds();
        _rewardedAds = new RewardedAds();

        AdvertismentEM.OnHideBannerAds += HideBannerAds;
        AdvertismentEM.OnShowBannerAds += ShowBannerAds;
    }

    private void ShowBannerAds()
    {
        _bannerAds.ShowBannerAd();
    }

    private void HideBannerAds()
    {
        _bannerAds.HideBannerAd();
    }
}
