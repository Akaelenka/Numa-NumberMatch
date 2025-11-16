using NumaModels;

public abstract class GameplayState : BaseState<EGameplayState>
{
    protected GameplayCore Core;

    public GameplayState(GameplayCore core, EGameplayState stateKey) : base(stateKey)
    {
        this.Core = core; 
    }
}
