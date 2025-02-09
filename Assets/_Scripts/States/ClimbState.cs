using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClimbState : State
{
    private float previousGravityScale = 2f;

    

    public UnityEvent OnClimb;
    

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.climb);
        agent.animationController.OnAnimationAction.AddListener(() => OnClimb.Invoke());
        agent.animationController.StopAnimation();
        previousGravityScale = agent.rb.gravityScale;
        agent.rb.gravityScale = 0;
        agent.rb.velocity = Vector2.zero; // stop player from moving if entering on the ladder
    }

    public void HandleDead()
    {
        print("dead");
    }

    protected override void ExitState()
    {
        agent.rb.gravityScale = previousGravityScale;
        agent.animationController.StartAnimation();
        agent.animationController.ResetEventListeners();
   
    }

    protected override void HandleJumpPressed()
    {
        agent.ChangeState(agent.stateFactory.GetState(StateType.Jump));
    }

    public override void UpdateState()
    {
        HandleMovementOnLadder();

        if (!agent.climbDetector.CanClimb)
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    private void HandleMovementOnLadder()
    {
        if (agent.agentInput.MovementVector.magnitude > 0) // if we are pressing any input key
        {
            agent.animationController.StartAnimation();
            agent.rb.velocity = new Vector2(agent.agentInput.MovementVector.x * agent.agentData.climbHorizontalSpeed,
                agent.agentInput.MovementVector.y * agent.agentData.climbVerticalSpeed);
        }
        else
        {
            agent.animationController.StopAnimation();
            agent.rb.velocity = Vector2.zero; // stop player from moving if not moving on the ladder
        }
    }

    protected override void HandleAttack()
    {
        //prevent attackking while climbing
    }

}
