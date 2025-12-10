using System;

public class AdvertisementEM
{
    public static event Action OnShowRewardedAds;
    public static event Action OnRewardedAdsCompleted;

    public static event Action OnShowBannerAds;
    public static event Action OnHideBannerAds;
    public static event Action OnInitAdvertismentDone;

    public static void ShowRewardedAds()
    {
        OnShowRewardedAds?.Invoke();
    }

    public static void CompleteRewardedAds()
    {
        OnRewardedAdsCompleted?.Invoke(); 
    }

    public static void ShowBannerAds()
    {
        OnShowBannerAds?.Invoke();
    }

    public static void HideBannerAds()
    {
        OnHideBannerAds?.Invoke();
    }

    public static void SetInitAdvertismentDone()
    {
        OnInitAdvertismentDone?.Invoke();
    }
}
