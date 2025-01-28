using UnityEngine;

public class FallState : MoveState
{
    public State ClimbState;

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
            agent.ChangeState(IdleState);
        }
        else if (agent.climbDetector.CanClimb && Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
        {
            agent.ChangeState(ClimbState);
        }
    }

}
