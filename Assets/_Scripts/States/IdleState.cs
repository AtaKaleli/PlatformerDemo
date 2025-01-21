using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class IdleState : State
{
    public State moveState;

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.idle);
    }

    protected override void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0)
        {
            agent.ChangeState(moveState);
        }
        
    }
}
