using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.AI
{
    public abstract class AIEnemyInput : MonoBehaviour, IAgentInput
    {
        public Vector2 MovementVector { get; set; }

        public event Action<Vector2> OnMovement;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action OnAttack;


        public void CallOnMovement(Vector2 input)
        {
            OnMovement?.Invoke(input);
        }

        public void CallOnJumpPressed()
        {
            OnJumpPressed?.Invoke();
        }

        public void CallOnJumpReleased()
        {
            OnJumpReleased?.Invoke();
        }

        public void CallOnAttack()
        {
            OnAttack?.Invoke();
        }

    }
}