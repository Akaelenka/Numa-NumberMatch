using NumaModels;

public class EndGameState : GameplayState
{
    public EndGameState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;
    }

    public override void StartState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void FinishState()
    {
    }

    public override EGameplayState GetNextState() 
    {
        return StateKey;
    }
}
