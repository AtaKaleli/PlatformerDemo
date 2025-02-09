using UnityEngine;
using UnityEngine.Events;

public class FallState : MoveState
{
    
    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.fall);
        
    }

    public override void UpdateState()
    {

        CalculateVelocity();
        SetPlayerVelocity();

        if (agent.groundDetector.CheckIsGrounded())
        {

            agent.ChangeState(agent.stateFactory.GetState(StateType.Idle));
        }
        else if (agent.climbDetector.CanClimb && Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Climb));
        }
    }


}
