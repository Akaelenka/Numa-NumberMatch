using NumaModels;

public abstract class PanelState : BaseState<EPanelType>
{
    public PanelState(EPanelType stateKey) : base(stateKey)
    {
    }
}
