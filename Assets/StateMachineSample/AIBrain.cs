
using UnityEngine;
public class AIBrain : MonoBehaviour
{
    public StateMachine<AIBrain> StateController;
    private void Awake()
    {
        Initialize();
        
        StateController.SetState(StateID.Move);
    }
    
    private void Initialize()
    {
        StateController = new StateMachine<AIBrain>();

        AIState<AIBrain> idleState = new IdleState(this);
        AIState<AIBrain> moveState = new MoveState(this);
        AIState<AIBrain> attackState = new AttackState(this);

        StateController.AddState(StateID.Idle , idleState);
        StateController.AddState(StateID.Move , moveState);
        StateController.AddState(StateID.Attack , attackState);
    }

    private void Update()
    {
        StateController.CurrentState.UpdateState();
    }

    private void FixedUpdate()
    {
        StateController.CurrentState.FixedUpdateState();
    }
    
    
    
}
