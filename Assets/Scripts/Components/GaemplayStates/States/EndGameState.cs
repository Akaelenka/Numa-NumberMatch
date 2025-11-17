using UnityEngine;
using NumaModels;

public class EndGameState : GameplayState
{
    public EndGameState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;
    }

    public override void StartState()
    {
        Debug.Log("EndGameState StartState");
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
        return StateKey;
    }
}
