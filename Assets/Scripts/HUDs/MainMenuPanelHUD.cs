using UnityEngine.Assertions;
using UnityEngine;

public class MainMenuPanelHUD : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuPanel;

    private ImageButtonComponent _startButton;
    private ImageButtonComponent _continueButton;

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
            }
            if (component.GetName() == "Continue Button")
            {
                _continueButton = component;
            }
        }

        Assert.IsNotNull(_startButton, $"[{gameObject.name}] No component with Start Game Button name");
        Assert.IsNotNull(_continueButton, $"[{gameObject.name}] No component with Continue Button name");

        if (_startButton != null) 
        {
            _startButton.GetButton().onClick.AddListener(StartGame);
        }
        if (_continueButton != null)
        {
            _continueButton.GetButton().onClick.AddListener(ContinueGame);
        }
    }

    private void StartGame()
    {
        PanelEM.StartGame();
    }

    private void ContinueGame()
    {
        PanelEM.ContinueGame();
    }
}
