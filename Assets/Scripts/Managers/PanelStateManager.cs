using NumaModels;

public class PanelStateManager : StateManager<EPanelType>
{
    private void Awake()
    {
        Initialized();
    }

    private void Initialized()
    {
        States.Add(EPanelType.Welcome, new WelcomePanelState(EPanelType.Welcome));
        States.Add(EPanelType.Loading, new LoadingPanelState(EPanelType.Loading));
        States.Add(EPanelType.MainMenu, new MainMenuPanelState(EPanelType.MainMenu));
        States.Add(EPanelType.Gameplay, new GameplayPanelState(EPanelType.Gameplay));
        States.Add(EPanelType.Pause, new PausePanelState(EPanelType.Pause));
        States.Add(EPanelType.EndGame, new EndGamePanelState(EPanelType.EndGame));

        CurrentState = States[EPanelType.Welcome];
    }
}
