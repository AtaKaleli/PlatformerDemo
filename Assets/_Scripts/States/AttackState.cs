using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{

    public LayerMask hittableLayerMask;

    protected Vector2 direction;

    public UnityEvent<AudioClip> OnWeaponSound;

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.attack);
        agent.animationController.OnAnimationAction.AddListener(PerformAttack);
        agent.animationController.OnAnimationEnd.AddListener(TransitionToState);

        agent.agentWeapon.ToggleWeaponVisibility(true);
        direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);

        if (agent.groundDetector.CheckIsGrounded())
        {
            agent.rb.velocity = Vector2.zero;
        }
         
    }


    private void PerformAttack()
    {
        OnWeaponSound?.Invoke(agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
        agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent, hittableLayerMask, direction);
    }


    private void TransitionToState()
    {
        if (agent.groundDetector.CheckIsGrounded())
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Idle));
        }
        else
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Fall));
        }
    }

    protected override void ExitState()
    {
        agent.agentWeapon.ToggleWeaponVisibility(false);
        agent.animationController.ResetEventListeners();
        
    }

    //override all the events so that no logic can interrupt the attack state
    protected override void HandleAttack()
    {
        
    }

    public override void UpdateState()
    {
        
    }

    public override void FixedUpdateState()
    {
        
    }

    protected override void HandleJumpReleased()
    {
        
    }

    protected override void HandleJumpPressed()
    {
        
    }
    
    protected override void HandleAgentFlip(Vector2 vector)
    {
        
    }
}
