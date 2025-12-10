using NumaModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;

public class FinishPanelHUD : MonoBehaviour
{
    [SerializeField]
    private Button _backToMenuButton;
    [SerializeField]
    private Button _bonusButton;
    [SerializeField]
    private TMP_Text _expValueText;

    private void Start()
    {
        Assert.IsNotNull(_backToMenuButton, $"[{gameObject.name}] BackToMenuButton is not assigned.");
        Assert.IsNotNull(_bonusButton, $"[{gameObject.name}] BonusButton is not assigned.");
        Assert.IsNotNull(_expValueText, $"[{gameObject.name}] ExpValueText is not assigned.");

        _backToMenuButton.onClick.AddListener(ToMainMenu);
        _bonusButton.onClick.AddListener(ShowRewardAds);

        AdvertisementEM.OnRewardedAdsCompleted += ToMainMenu;
    }

    private void ToMainMenu()
    {
        PanelEM.TriggerToMainMenu();
    }

    private void ShowRewardAds()
    {
        AdvertisementEM.HideBannerAds();
        AdvertisementEM.ShowRewardedAds();
    }
}
