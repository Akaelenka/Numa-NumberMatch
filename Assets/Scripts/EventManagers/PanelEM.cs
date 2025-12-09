using System;
using NumaModels;

public class PanelEM
{
    public static event Action<EPanelType> OnChangePanel;
    public static event Action OnStartIntro;
    public static event Action OnStartTutorial;
    public static event Action OnStartGame;
    public static event Action OnContinueGame;
    public static event Action OnFinishGame;
    public static event Action OnQuitGame;
    public static event Action OnTriggerToMainMenu;

    public static void ChangePanel(EPanelType panel)
    {
        OnChangePanel?.Invoke(panel);
    }

    public static void StartIntro()
    {
        OnStartIntro?.Invoke();
    }

    public static void StartTutorial()
    {
        OnStartTutorial?.Invoke();
    }

    public static void StartGame()
    {
        OnStartGame?.Invoke();
    }

    public static void ContinueGame()
    {
        OnContinueGame?.Invoke();
    }

    public static void FinishGame() 
    { 
        OnFinishGame?.Invoke(); 
    }

    public static void QuitGame()
    {
        OnQuitGame?.Invoke();
    }

    public static void TriggerToMainMenu() 
    {
        OnTriggerToMainMenu?.Invoke();
    }
}
