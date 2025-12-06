using UnityEngine;
using NumaModels;

public class SelectTileState : GameplayState
{
    public SelectTileState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;

        TileNewEM.OnTileMatched += OnTileMatched;

        PanelEM.OnQuitGame += OnBackToMainMenu;
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

        if (Core.IsReachedTargetScore)
        {
            NextState = EGameplayState.EndGame;
        }
        if (Core.IsBackToMainMenu)
        {
            NextState = EGameplayState.Idle;

            Core.IsBackToMainMenu = false;
        }
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

    private void OnBackToMainMenu()
    {
        Core.IsBackToMainMenu = true;
    }
}
