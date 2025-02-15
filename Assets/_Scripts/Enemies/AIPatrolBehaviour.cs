using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.AI
{
    public class AIPatrolBehaviour : AIBehaviour
    {
        public AIEndPlatformDetector changeDirectionDetector;

        private Vector2 movementVector;




        private void Awake()
        {
            if (changeDirectionDetector == null)
                changeDirectionDetector = GetComponentInChildren<AIEndPlatformDetector>();

        }

        private void Start()
        {
            changeDirectionDetector.OnPathBlocked += HandlePathBlocked;
            movementVector = new Vector2(Random.value > 0.5f ? 1 : -1 , 0); // determine which direction to start patrol at the beginning
        }

        private void HandlePathBlocked()
        {
            movementVector *= new Vector2(-1, 0); // change x direction
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = movementVector;
            enemyAI.CallOnMovement(movementVector);
        }
    }
}