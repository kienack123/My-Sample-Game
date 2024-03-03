using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AIState<T> where T : MonoBehaviour
{
    protected T aiBrain;
    protected AIState(T controller)
    {
        aiBrain = controller;
    }
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void FixedUpdateState();
    
    public abstract void ExitState();
}
