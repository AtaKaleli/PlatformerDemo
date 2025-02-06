using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;


public class Agent : MonoBehaviour
{
    public AgentDataSO agentData;

    public Rigidbody2D rb;
    public PlayerInput agentInput;
    public AgentAnimation animationController;
    public AgentRenderer agentRenderer;
    public GroundDetector groundDetector;
    public ClimbDetector climbDetector;
    
    [HideInInspector] public AgentWeaponManager agentWeapon;
    

    public State IdleState;
    private State currentState = null;


    public UnityEvent OnRespawnRequired;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        agentInput = GetComponentInParent<PlayerInput>();
        animationController = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        groundDetector = GetComponentInChildren<GroundDetector>();
        climbDetector = GetComponentInChildren<ClimbDetector>();
        agentWeapon = GetComponentInChildren<AgentWeaponManager>();
        
        AssignAgentToStates();

    }

    

    private void Start()
    {
        agentInput.OnMovement += agentRenderer.FlipController;
        ChangeState(IdleState);
    }

    private void Update()
    {

        currentState.UpdateState();
    }

    private void FixedUpdate()
    {
        groundDetector.CheckIsGrounded();
        currentState.FixedUpdateState();
    }

    private void AssignAgentToStates()
    {
        State[] states = GetComponentsInChildren<State>();
        foreach (var state in states)
        {
            state.InitializeState(this);
        }
    }

    public void ChangeState(State newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.Enter();
        }
    }

    public void AgentDied()
    {
        OnRespawnRequired?.Invoke();
    }
   
}
