using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitState : State
{


    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.hit);
        agent.animationController.OnAnimationEnd.AddListener(TransitionToIdle);
    }

    private void TransitionToIdle()
    {
        //agent.animationController.OnAnimationEnd.RemoveListener(TransitionToIdle);
        agent.ChangeState(agent.stateFactory.GetState(StateType.Idle));
    }

    protected override void ExitState()
    {
        agent.animationController.ResetEventListeners();
    }

    protected override void HandleAttack()
    {
        // prevent attacking
    }

    protected override void HandleJumpPressed()
    {
        // prevent jumping
    }

    public override void UpdateState()
    {
        // prevent also falling
    }

    public override void GetHit()
    {
        // prevent got hit twice
    }


}
