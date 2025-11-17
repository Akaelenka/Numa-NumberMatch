using NUnit.Framework;
using UnityEngine;

public class MainMenuPanelHUD : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuPanel;

    private ImageButtonComponent _startButton;

    private void Awake()
    {
        Assert.IsNotNull(_mainMenuPanel, $"[{gameObject.name}] MainMenuPanel is not assigned.");
    }

    private void Start()
    {
        foreach (var component in _mainMenuPanel.GetComponents<ImageButtonComponent>()) 
        {
            if (component.GetName() == "Start Game Button")
            {
                _startButton = component;
                break;
            }

            Debug.Log($"[{gameObject.name}] No component with Start Game Button name");
        }

        if (_startButton != null) 
        {
            _startButton.GetButton().onClick.AddListener(StartGame);
        }
    }

    private void StartGame()
    {
        PanelEM.StartGame();
    }
}
