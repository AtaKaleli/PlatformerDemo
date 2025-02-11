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
    private Damagable damagable;
    
    [HideInInspector] public AgentWeaponManager agentWeapon;
    

    
    private State currentState = null;

    [HideInInspector] public StateFactory stateFactory;

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
        stateFactory = GetComponentInChildren<StateFactory>();
        damagable = GetComponent<Damagable>();

        stateFactory.InitializeStates(this);

    }

    

    private void Start()
    {
        InitializeAgent();
    }

    private void InitializeAgent()
    {
        ChangeState(stateFactory.GetState(StateType.Idle));
        damagable.InitializeHealth(agentData.health);
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

    public void AgentGetHit()
    {
        //to be implemented
    }
   
   
}
