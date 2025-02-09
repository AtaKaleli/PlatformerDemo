using UnityEngine;

public class IdleState : State
{
    
    

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.idle);

        if (agent.groundDetector.CheckIsGrounded())
        {
            agent.rb.velocity = Vector2.zero;
        }
    }

    protected override void HandleAgentFlip(Vector2 input)
    {
        if (agent.climbDetector.CanClimb && Mathf.Abs(input.y) > 0) // if we are in the ladder and pressed the up key
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Climb));
        }
        else if (Mathf.Abs(input.x) > 0.01f)
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Move));
        }
    }

}
