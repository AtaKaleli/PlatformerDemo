using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class IdleState : State
{
    [Header("State Information")]
    public State MoveState;

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.idle);
    }

    protected override void HandleMovement(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0.01f)
        {
            agent.ChangeState(MoveState);
        }
    }

}
