using NumaModels;

public class GameplayPanelState : PanelState
{
    public GameplayPanelState(EPanelType stateKey) : base(stateKey)
    {
        PanelEM.OnFinishGame += FinishGame;
        PanelEM.OnQuitGame += QuitGame;
    }

    public override void StartState()
    {
        NextState = StateKey;

        PanelEM.ChangePanel(EPanelType.Gameplay);
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

    private void FinishGame() 
    {
        NextState = EPanelType.EndGame;
    }

    private void QuitGame()
    {
        NextState = EPanelType.MainMenu;
    }
}
