using UnityEngine;
using UnityEngine.Events;

public class MoveState : State
{
    protected MovementData movementData;

    public UnityEvent OnMove;



    private void Awake()
    {
        movementData = GetComponentInParent<MovementData>();
    }

    protected override void EnterState()
    {
        agent.animationController.PlayAnimation(AnimationType.run);
        agent.animationController.OnAnimationAction.AddListener(() => OnMove.Invoke());
        
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        CalculateVelocity();
        SetPlayerVelocity(); // finally, set the player rb velocity

        if (Mathf.Abs(agent.rb.velocity.x) < 0.01f)
        {
            agent.ChangeState(agent.stateFactory.GetState(StateType.Idle));
        }
    }

    protected override void HandleAgentFlip(Vector2 input)
    {
        agent.agentRenderer.FlipController(input);
    }


    protected void CalculateVelocity()
    {
        movementData.movementVector = agent.agentInput.MovementVector; // setting the movement input vector to movement data

        CalculateHorizontalDirection(movementData);
        CalculateSpeed(movementData);

        movementData.currentVelocity =
            new Vector2(movementData.horizontalMovementDirection * movementData.currentSpeed, agent.rb.velocity.y);
    }

    protected void CalculateHorizontalDirection(MovementData movementData) // calculates the direction of the player
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

    protected void CalculateSpeed(MovementData movementData) // instead of simple speed value, we calculated the speed with acc and deacc values
    {

        if(Mathf.Abs(movementData.movementVector.x) > 0)
        {
            movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
        }
        else
        {
            movementData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;
        }

        // make sure that speed do not exceed the max and min limits as we are increasing and decreasing it in the calculation
        movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.agentData.maxSpeed); 

    }

    protected void SetPlayerVelocity() // simply sets the player's velocity to movementdata velocity that we have calculated
    {
        agent.rb.velocity = movementData.currentVelocity;
    }

    protected override void ExitState()
    {
        agent.animationController.ResetEventListeners();
    }

}
