using NumaModels;

public class GameplayStateManager : StateManager<EGameplayState>
{
    private GameplayCore _gameplayCore;

    private void Awake()
    {
        _gameplayCore = new GameplayCore();
        Initialized();
    }

    private void Initialized()
    {
        States.Add(EGameplayState.Idle, new IdleState(_gameplayCore, EGameplayState.Idle));
        States.Add(EGameplayState.PrepareGame, new PrepareGameState(_gameplayCore, EGameplayState.PrepareGame));
        States.Add(EGameplayState.SelectTile, new SelectTileState(_gameplayCore, EGameplayState.SelectTile));
        States.Add(EGameplayState.CheckMatches, new CheckMatchesState(_gameplayCore, EGameplayState.CheckMatches));
        States.Add(EGameplayState.EndGame, new EndGameState(_gameplayCore, EGameplayState.EndGame));

        CurrentState = States[EGameplayState.Idle];
    }
}
