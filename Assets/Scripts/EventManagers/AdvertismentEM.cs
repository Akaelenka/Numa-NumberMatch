using System;

public class AdvertismentEM
{
    public static event Action OnShowBannerAds;
    public static event Action OnHideBannerAds;

    public static void ShowBannerAds()
    {
        OnShowBannerAds?.Invoke();
    }

    public static void HideBannerAds()
    {
        OnHideBannerAds?.Invoke();
    }
}
