using NumaModels;
using UnityEngine;

public class IdleState : GameplayState
{
    public IdleState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;

        PanelEM.OnChangePanel += StartPrepareTheGame;

        PanelEM.OnStartGame += StartNewGame;
        PanelEM.OnContinueGame += StartContinueGame;
    }

    public override void StartState()
    {
        Debug.Log("IdleState StartState");
        NextState = StateKey;

        AdvertisementEM.HideBannerAds();
    }

    public override void UpdateState()
    {
        Debug.Log("IdleState UpdateState");
    }

    public override void FinishState()
    {
    }

    public override EGameplayState GetNextState()
    {
        return NextState;
    }

    private void StartPrepareTheGame(EPanelType panelType) 
    {
        if (panelType == EPanelType.Gameplay)
        {
            NextState = EGameplayState.PrepareGame;
        }
    }

    private void StartNewGame()
    {
        Core.GameSelection = EGameSelection.Start;
    }

    private void StartContinueGame()
    {
        Core.GameSelection = EGameSelection.Continue;
    }
}
