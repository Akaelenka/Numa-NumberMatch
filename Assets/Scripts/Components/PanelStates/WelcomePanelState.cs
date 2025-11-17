using NumaModels;
using System;
using System.Diagnostics;

public class WelcomePanelState : PanelState
{
    public WelcomePanelState(EPanelType stateKey) : base(stateKey)
    {
    }

    private int _maxLoading = 100;
    private int _currentLoading = 0;

    public override void StartState()
    {
        NextState = StateKey;
        _currentLoading = 0;

        PanelEM.ChangePanel(EPanelType.Welcome);
    }

    public override void UpdateState()
    {
        _currentLoading++;

        if (_currentLoading >= _maxLoading) 
        {
            NextState = EPanelType.Loading;
        }
    }

    public override void FinishState()
    {
    }

    public override EPanelType GetNextState()
    {
        return NextState;
    }
}
