using NumaModels;
using UnityEngine;

public class PrepareGameState : GameplayState
{
    public PrepareGameState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;
    }

    public override void StartState()
    {
        Debug.Log("PrepareGameState StartState");
        NextState = StateKey;

        Core.ResetTiles();
        Core.GenerateTiles(90);

        NextState = EGameplayState.SelectTile;
    }

    public override void UpdateState()
    {
        Debug.Log("PrepareGameState UpdateState");
    }

    public override void FinishState()
    {
    }

    public override EGameplayState GetNextState() 
    {
        return NextState;
    }
}
