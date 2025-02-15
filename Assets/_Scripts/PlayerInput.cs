using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    public Vector2 MovementVector { get; private set; }

    public event Action<Vector2> OnMovement;

    public event Action OnJumpPressed, OnJumpReleased, OnAttack;

    public KeyCode jumpKey, attackKey;


    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
        }
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            OnJumpPressed?.Invoke();
        }
        if (Input.GetKeyUp(jumpKey))
        {
            OnJumpReleased?.Invoke();
        }
    }

    private void GetMovementInput()
    {
        MovementVector = GetMovementVector();
        OnMovement?.Invoke(MovementVector);
    }

    private Vector2 GetMovementVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(attackKey))
        {
            OnAttack?.Invoke();
        }
    }


}
