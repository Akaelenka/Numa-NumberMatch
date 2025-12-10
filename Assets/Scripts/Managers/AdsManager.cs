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

        _rewardedAds.OnRewardedAdsCompleted += CompleteRewardedAds;

        AdvertisementEM.OnInitAdvertismentDone += LoadRewardedAds;
        AdvertisementEM.OnInitAdvertismentDone += LoadBannerAds;

        AdvertisementEM.OnShowRewardedAds += ShowRewardedAds;
        AdvertisementEM.OnHideBannerAds += HideBannerAds;
        AdvertisementEM.OnShowBannerAds += ShowBannerAds;
    }

    private void CompleteRewardedAds()
    {
        AdvertisementEM.CompleteRewardedAds();
    }

    private void LoadRewardedAds()
    {
        _rewardedAds.LoadRewardedAd();
    }

    private void ShowRewardedAds()
    {
        _rewardedAds.ShowRewardedAd();
        LoadRewardedAds();
    }

    private void LoadBannerAds()
    {
        _bannerAds.LoadBannerAd();
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
