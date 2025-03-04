using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IAgentInput
{
    

    public KeyCode jumpKey, attackKey, swapWeaponKey;

    public event Action<Vector2> OnMovement;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action OnAttack;
    public event Action OnSwapWeapon;

    public Vector2 MovementVector { get; private set; }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetSwapWeaponInput();
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

    private void GetSwapWeaponInput()
    {
        if (Input.GetKeyDown(swapWeaponKey))
        {
            OnSwapWeapon?.Invoke();
        }
    }
}
