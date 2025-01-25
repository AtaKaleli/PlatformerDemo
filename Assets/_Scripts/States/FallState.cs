using UnityEngine;

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
            agent.ChangeState(IdleState);
        }
    }

}
