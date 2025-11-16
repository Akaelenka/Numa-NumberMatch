using UnityEngine;
using NumaModels;
using System;

public class CheckMatchesState : GameplayState
{
    public CheckMatchesState(GameplayCore core, EGameplayState stateKey) : base(core, stateKey)
    {
        Core = core;

        TileNewEM.OnFinishCheckMatchedTile += OnFinishCheckMatchedTile;
    }

    public override void StartState()
    {
        Debug.Log("CheckMatchesState StartState");
        NextState = StateKey;

        Core.CheckMatchedTiles();
    }

    public override void UpdateState()
    {
        Debug.Log("CheckMatchesState UpdateState");
    }

    public override void FinishState()
    {
    }

    public override EGameplayState GetNextState() 
    {
        return NextState;
    }

    private void OnFinishCheckMatchedTile()
    {
        NextState = EGameplayState.SelectTile;
    }
}
