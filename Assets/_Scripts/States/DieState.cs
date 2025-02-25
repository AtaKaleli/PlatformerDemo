using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State
{
    [SerializeField] private float timeToWaitBeforeDie = 2f;



    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.die);
        agent.animationController.OnAnimationEnd.AddListener(WaitBeforeDieAction);
        
    }

    private void WaitBeforeDieAction()
    {
        //agent.animationController.OnAnimationEnd.RemoveListener(WaitBeforeDieAction);
        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(timeToWaitBeforeDie);
        agent.OnAgentDie?.Invoke();
    }

    protected override void ExitState()
    {
        StopAllCoroutines();
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
        agent.rb.velocity = new Vector2(0, agent.rb.velocity.y);
        // prevent also falling
    }

    public override void GetHit()
    {
        // prevent got hit twice
    }
    public override void Die()
    {
        // prevent die twice
    }















}
