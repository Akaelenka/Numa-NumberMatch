using NumaModels;

public class EndGamePanelState : PanelState
{
    public EndGamePanelState(EPanelType stateKey) : base(stateKey)
    {
        PanelEM.OnTriggerToMainMenu += GoToMainMenu;
    }

    public override void StartState()
    {
        NextState = StateKey;

        PanelEM.ChangePanel(EPanelType.EndGame);
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

    private void GoToMainMenu() 
    {
        NextState = EPanelType.MainMenu;
    }
}
