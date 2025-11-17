using UnityEngine;
using NumaModels;

public class LoadingPanelState : PanelState
{
    public LoadingPanelState(EPanelType stateKey) : base(stateKey)
    {
        LoadingEM.OnLoadingComplete += CompleteLoadingProgression;
    }

    private int _currentProgression = 0;

    public override void StartState()
    {
        NextState = StateKey;
        _currentProgression = 0;

        PanelEM.ChangePanel(EPanelType.Loading);
        LoadingEM.ResetProgression();
    }

    public override void UpdateState()
    {
        Debug.Log($"[{this.GetType().Name}] Loading progression: {_currentProgression}%.");

        _currentProgression += 1;
        LoadingEM.UpdateProgression(_currentProgression);
    }

    public override void FinishState()
    {
    }

    public override EPanelType GetNextState()
    {
        return NextState;
    }

    private void CompleteLoadingProgression()
    {
        NextState = EPanelType.MainMenu;
    }
}
