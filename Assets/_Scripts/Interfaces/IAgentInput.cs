using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentInput 
{
    public Vector2 MovementVector { get; }

    public event Action<Vector2> OnMovement;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action OnAttack;
}
