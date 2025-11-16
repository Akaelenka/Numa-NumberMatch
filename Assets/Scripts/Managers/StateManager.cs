using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected bool IsTransitioningState = false;
    public BaseState<EState> CurrentState { get; protected set; }

    private void Start()
    {
        CurrentState?.StartState();
    }

    private void Update()
    {
        EState nextStateKey = CurrentState.GetNextState();

        if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState?.UpdateState();
        }
        else if (!IsTransitioningState)
        {
            Debug.Log($"Switching State from {CurrentState.StateKey} to {nextStateKey}");

            SwitchState(nextStateKey);
        }
    }

    public void SwitchState(EState state)
    {
        IsTransitioningState = true;

        CurrentState.FinishState();
        CurrentState = States[state];
        CurrentState.StartState();
        
        IsTransitioningState = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    CurrentState?.OnEnterStartState(other);
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    CurrentState?.OnEnterUpdateState(other);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    CurrentState?.OnEnterFinishState(other);
    //}
}
