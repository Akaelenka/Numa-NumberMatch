using System;

public abstract class BaseState<EState> where EState : Enum
{
    public BaseState(EState key)
    {
        StateKey = key;
    }

    public EState StateKey { get; private set; }
    public EState NextState { get; protected set; }

    public abstract void StartState();
    public abstract void UpdateState();
    public abstract void FinishState();
    public abstract EState GetNextState();
    //public abstract void OnEnterStartState(Collider other);
    //public abstract void OnEnterUpdateState(Collider other);
    //public abstract void OnEnterFinishState(Collider other);
}


