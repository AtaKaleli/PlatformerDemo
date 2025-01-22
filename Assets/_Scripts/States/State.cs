using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    //public UnityEvent OnEnter, OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnMovement += HandleMovement;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        //OnEnter?.Invoke();
        EnterState();
    }

    public void Exit()
    {
        this.agent.agentInput.OnMovement -= HandleMovement;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        //OnExit?.Invoke();
        ExitState();
    }



    #region Main States
    protected virtual void EnterState()
    {
    }

    public virtual void UpdateState()
    {

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
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
    }
    #endregion
}
