using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    [SerializeField] protected State JumpState, FallState, AttackState;

    public UnityEvent OnEnter,OnExit; // those are used for only one time happened animations, like jump and fall

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnMovement += HandleAgentFlip;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        this.agent.agentInput.OnAttack += HandleAttack;
        OnEnter?.Invoke();
        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnMovement -= HandleAgentFlip;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnAttack -= HandleAttack;
        OnExit?.Invoke();
        ExitState();
    }



    #region Main States
    protected virtual void EnterState()
    {
    }

    public virtual void UpdateState()
    {
        TestFallTransition();
    }

    private void TestFallTransition()
    {
        if (!agent.groundDetector.CheckIsGrounded())
        {
            agent.ChangeState(FallState);
        }
    }
    
    private void TestAttackTransition()
    {
        if (agent.agentWeapon.CanIUseWeapon(agent.groundDetector.CheckIsGrounded()))
        {
            agent.ChangeState(AttackState);
        }
    }

    public virtual void FixedUpdateState()
    {
        
    }

    protected virtual void ExitState()
    {
        
    }

    #endregion

    #region Events

    protected virtual void HandleJumpReleased()
    {
    }

    protected virtual void HandleJumpPressed()
    {
        TestJumpTransition();
    }

    private void TestJumpTransition()
    {
        if (agent.groundDetector.CheckIsGrounded())
        {
            agent.ChangeState(JumpState);
        }
    }

    protected virtual void HandleAgentFlip(Vector2 vector)
    {
    }

    protected virtual void HandleAttack()
    {
        TestAttackTransition();
    }

    #endregion
}
