using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementData : MonoBehaviour
{
    public float horizontalMovementDirection;
    public float currentSpeed;
    public Vector2 currentVelocity;
    public Vector2 movementVector;

    public void ResetMovement()
    {
        horizontalMovementDirection = 0;
        currentSpeed = 0;
        currentVelocity = Vector2.zero;
    }


}
