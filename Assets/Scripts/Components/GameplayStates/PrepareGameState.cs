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

        if (Core.GameSelection == EGameSelection.Start)
        {
            Core.GenerateTiles(GameSettingsUtilities.TotalGeneratedTile);
        }
        else if (Core.GameSelection == EGameSelection.Continue)
        {
            SaveEM.LoadData();
        }

        Core.GameSelection = EGameSelection.None;
        NextState = EGameplayState.SelectTile;
    }

    public override void UpdateState()
    {
        Debug.Log("PrepareGameState UpdateState");
    }

    public override void FinishState()
    {
        AdvertismentEM.ShowBannerAds();
    }

    public override EGameplayState GetNextState() 
    {
        return NextState;
    }
}
