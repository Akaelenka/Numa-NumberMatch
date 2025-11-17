using UnityEngine;
using NumaModels;
using NUnit.Framework;
using System.Collections.Generic;

public class PanelHUD : MonoBehaviour
{
    [SerializeField]
    private GameObject WelcomePanel;
    [SerializeField]
    private GameObject LoadingPanel;
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject GameplayPanel;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private GameObject EndGamePanel;
    [SerializeField]
    private GameObject HeaderPanel;

    private List<GameObject> _panels;

    private void Awake()
    {
        Assert.IsNotNull(WelcomePanel, $"[{gameObject.name}] WelcomePanel is not assigned.");
        Assert.IsNotNull(LoadingPanel, $"[{gameObject.name}] LoadingPanel is not assigned.");
        Assert.IsNotNull(MainMenuPanel, $"[{gameObject.name}] MainMenuPanel is not assigned.");
        Assert.IsNotNull(GameplayPanel, $"[{gameObject.name}] GameplayPanel is not assigned.");
        Assert.IsNotNull(PausePanel, $"[{gameObject.name}] PausePanel is not assigned.");
        Assert.IsNotNull(EndGamePanel, $"[{gameObject.name}] EndGamePanel is not assigned.");

        _panels = new List<GameObject>
        {
            WelcomePanel,
            LoadingPanel,
            MainMenuPanel,
            GameplayPanel,
            PausePanel,
            EndGamePanel
        };

        PanelEM.OnChangePanel += ChangePanel;
    }

    private void ChangePanel(EPanelType panelType)
    {
        if (panelType == EPanelType.Pause)
        {
            PausePanel.SetActive(true);
            return;
        }
        if (panelType == EPanelType.EndGame)
        {
            EndGamePanel.SetActive(true);
            return;
        }

        foreach (GameObject panel in _panels) 
        {
            panel.SetActive(false);
        }

        switch (panelType) 
        {
            case EPanelType.Welcome:
                WelcomePanel.SetActive(true);
                break;
            case EPanelType.Loading:
                LoadingPanel.SetActive(true);
                break;
            case EPanelType.MainMenu:
                HeaderPanel.SetActive(true);
                MainMenuPanel.SetActive(true);
                break;
            case EPanelType.Gameplay:
                HeaderPanel.SetActive(true);
                GameplayPanel.SetActive(true);
                break;
            default:
                Debug.LogWarning($"[{gameObject.name}] Unsupported panel type: {panelType}");
                break;
        }
    }
}
