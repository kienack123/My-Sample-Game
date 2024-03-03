using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : MonoBehaviour
{
    private Dictionary<StateID, AIState<T>> _stateMachine = new Dictionary<StateID, AIState<T>>();

    public AIState<T> CurrentState;

    public AIState<T> PreviousState;
    
    public void AddState(StateID id , AIState<T> state)
    {
        _stateMachine.Add(id , state);
    }
    
    public void SetState(StateID id)
    {
        if (CurrentState != null)
        {
            CurrentState.ExitState();
            PreviousState = CurrentState;
        }
        CurrentState = _stateMachine[id]; 

        CurrentState.EnterState(); 
    }
    
}
public enum StateID
{
    Idle,
    Move,
    Attack
}