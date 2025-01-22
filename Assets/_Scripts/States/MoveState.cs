using UnityEngine;

public class MoveState : State
{
    private MovementData movementData;

    [Header("State Information")]
    public State IdleState;

    public float acceleration, deacceleration, maxSpeed;

    private void Awake()
    {
        movementData = GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.run);
        movementData.ResetMovement(); // just for be cautious about precise movement calculation
    }

    public override void UpdateState()
    {
        CalculateVelocity();
        
        if (Mathf.Abs(agent.rb.velocity.x) < 0.01f)
        {
            agent.ChangeState(IdleState);
        }
    }


    private void CalculateVelocity()
    {
        movementData.movementVector = agent.agentInput.MovementVector; // setting the movement input vector to movement data

        CalculateHorizontalDirection(movementData);
        CalculateSpeed(movementData);

        movementData.currentVelocity =
            new Vector2(movementData.horizontalMovementDirection * movementData.currentSpeed, agent.rb.velocity.y);

        SetPlayerVelocity();

    }

    private void CalculateHorizontalDirection(MovementData movementData) // calculates the direction of the player
    {
        if (movementData.movementVector.x > 0)
        {
            movementData.horizontalMovementDirection = 1;
        }
        else if (movementData.movementVector.x < 0)
        {
            movementData.horizontalMovementDirection = -1;
        }
    }

    private void CalculateSpeed(MovementData movementData) // instead of simple speed value, we calculated the speed with acc and deacc values
    {
        if(Mathf.Abs(movementData.movementVector.x) > 0)
        {
            movementData.currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            movementData.currentSpeed -= deacceleration * Time.deltaTime;
        }

        // make sure that speed do not exceed the max and min limits as we are increasing and decreasing it in the calculation
        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, maxSpeed); 

    }

    private void SetPlayerVelocity() // simply sets the player's velocity to movementdata velocity that we have calculated
    {
        agent.rb.velocity = movementData.currentVelocity;
    }
}
