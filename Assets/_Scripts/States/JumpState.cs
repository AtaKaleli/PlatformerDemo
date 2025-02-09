using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpState : MoveState
{

    private bool jumpPressed;

    
    


    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.jump);
        
        movementData.currentVelocity = new Vector2(agent.rb.velocity.x, agent.agentData.jumpForce);
       
        SetPlayerVelocity();
        jumpPressed = true;
    }

    protected override void HandleJumpPressed()
    {
        jumpPressed = true;
    }

    protected override void HandleJumpReleased()
    {
        jumpPressed = false;
    }

    public override void UpdateState()
    {
        CalculateVelocity();
        SetPlayerVelocity();

        ControlJumpHeight();
        if (agent.rb.velocity.y <= 0)
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Fall));
        }
        else if (agent.climbDetector.CanClimb && Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Climb));
        }
    }

    private void ControlJumpHeight()
    {
        if (!jumpPressed)
        {
            movementData.currentVelocity = agent.rb.velocity;
            movementData.currentVelocity.y += agent.agentData.gravityModifier * Physics2D.gravity.y * Time.deltaTime;
            SetPlayerVelocity();
        }
    }

}
