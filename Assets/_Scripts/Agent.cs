using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private AgentAnimation animationManager;
    private AgentRenderer agentRenderer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponentInParent<PlayerInput>();
        animationManager = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
    }


    private void Start()
    {
        playerInput.OnMovement += HandleMovement;
        playerInput.OnMovement += agentRenderer.FaceDirection;
    }

    private void HandleMovement(Vector2 input)
    {
        if(Mathf.Abs(input.x) > 0)
        {
            if(MathF.Abs(rb.velocity.x) < 0.01f)
            {
                animationManager.PlayAnimation(AnimationType.run);
            }
            rb.velocity = new Vector2(input.x * 5f, rb.velocity.y);
        }
        else
        {
            if (MathF.Abs(rb.velocity.x) > 0.01f)
            {
                animationManager.PlayAnimation(AnimationType.idle);
            }
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
