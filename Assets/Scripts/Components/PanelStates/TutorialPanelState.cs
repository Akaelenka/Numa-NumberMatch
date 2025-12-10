using NumaModels;
using System;
using System.Diagnostics;

public class TutorialPanelState : PanelState
{
    public TutorialPanelState(EPanelType stateKey) : base(stateKey)
    {
        PanelEM.OnTutorialDone += GoToNextState;
    }

    public override void StartState()
    {
        NextState = StateKey;
        PanelEM.ChangePanel(EPanelType.Tutorial);
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

    private void GoToNextState() 
    {
        NextState = EPanelType.MainMenu;
    }
}
