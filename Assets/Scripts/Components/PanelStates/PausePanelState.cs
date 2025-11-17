using NumaModels;

public class PausePanelState : PanelState
{
    public PausePanelState(EPanelType stateKey) : base(stateKey)
    {

    }

    public override void StartState()
    {
        NextState = StateKey;
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
}
