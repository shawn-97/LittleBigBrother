using UnityEngine;

public class PlayerStateMachine
{
    public PlayerEntityState currentState { get; private set; }

    public void Initialize(PlayerEntityState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerEntityState _newState)
    {
        currentState.Exit();
        currentState=_newState;  
        currentState.Enter();
    }

    public void UpdateActiveState()
    {
        currentState.Update();
    }
}
