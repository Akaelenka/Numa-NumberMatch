using UnityEngine;
using NumaModels;

public class SelectTileState : GameplayState
{
    public SelectTileState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;

        TileNewEM.OnTileMatched += OnTileMatched;
    }

    public override void StartState()
    {
        Debug.Log("SelectTileState StartState");
        NextState = StateKey;

        TileNewEM.SetBlockerActive(false);
    }

    public override void UpdateState()
    {
        Debug.Log("SelectTileState UpdateState");
    }

    public override void FinishState()
    {
        Debug.Log("SelectTileState FinishState");

        TileNewEM.SetBlockerActive(true);
    }

    public override EGameplayState GetNextState() 
    {
        return NextState;
    }

    private void OnTileMatched()
    {
        NextState = EGameplayState.CheckMatches;
    }
}
