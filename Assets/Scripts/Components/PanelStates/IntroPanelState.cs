using NumaModels;

public class IntroPanelState : PanelState
{
    private bool _isActive;

    public IntroPanelState(EPanelType stateKey) : base(stateKey)
    {
        SaveEM.OnLoadPlayerDataResult += GoToNext;
    }

    public override void StartState()
    {
        NextState = StateKey;
        PanelEM.ChangePanel(EPanelType.Introduction);

        _isActive = true;
    }

    public override void UpdateState()
    {
    }

    public override void FinishState()
    {
        _isActive = false;
    }

    public override EPanelType GetNextState()
    {
        return NextState;
    }

    private void GoToNext(PlayerDataModel data)
    {
        if (_isActive)
        {
            NextState = EPanelType.Tutorial;
        }
    }
}
