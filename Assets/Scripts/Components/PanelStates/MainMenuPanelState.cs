using NumaModels;

public class MainMenuPanelState : PanelState
{
    public MainMenuPanelState(EPanelType stateKey) : base(stateKey)
    {
        PanelEM.OnStartGame += ShowGameplay;
    }

    public override void StartState()
    {
        NextState = StateKey;

        PanelEM.ChangePanel(EPanelType.MainMenu);
    }

    public override void UpdateState()
    {
    }

    public override void FinishState()
    {
    }

    public override EPanelType GetNextState()
    {
        return NextState;
    }

    private void ShowGameplay()
    {
        NextState = EPanelType.Gameplay;
    }
}
