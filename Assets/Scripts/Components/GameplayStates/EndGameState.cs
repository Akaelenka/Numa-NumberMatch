using UnityEngine;
using NumaModels;

public class EndGameState : GameplayState
{
    public EndGameState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;

        PanelEM.OnChangePanel += BakcToIdle;
    }

    public override void StartState()
    {
        Debug.Log("EndGameState StartState");
        NextState = StateKey;

        PanelEM.FinishGame();
    }

    public override void UpdateState()
    {
        Debug.Log("EndGameState UpdateState");
    }

    public override void FinishState()
    {
    }

    public override EGameplayState GetNextState() 
    {
        return NextState;
    }

    private void BakcToIdle(EPanelType type)
    {
        if (type == EPanelType.MainMenu)
        {
            NextState = EGameplayState.Idle;
        }
    }
}
