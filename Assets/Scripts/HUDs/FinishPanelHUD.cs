using NumaModels;
using UnityEngine;
using UnityEngine.UI;

public class FinishPanelHUD : MonoBehaviour
{
    [SerializeField]
    private Button _backToMenuButton;

    private void Start()
    {
        _backToMenuButton.onClick.AddListener(BackToMainMenu);
    }

    private void BackToMainMenu()
    {
        PanelEM.TriggerToMainMenu();
    }
}
