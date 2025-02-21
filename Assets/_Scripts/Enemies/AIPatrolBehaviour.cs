using UnityEngine;

namespace MG.AI
{
    public class AIPatrolBehaviour : AIBehaviour
    {
        [SerializeField] private AIFlipDetector aiFlipDetector;
        private Vector2 movementVector;



        private void Start()
        {
            aiFlipDetector.OnPathBlocked += HandlePathBlocked;
            movementVector = new Vector2(Random.value > 0.5f ? 1 : -1, 0); // select the start direction randomly
        }

        private void HandlePathBlocked()
        {
            movementVector *= new Vector2(-1, 0); // simply changes the movement direction of x coordinate
        }

        public override void PerformBehaviour(AIEnemyInput enemyAI)
        {
            enemyAI.MovementVector = movementVector;
            enemyAI.CallOnMovement(movementVector);
        }
    }
}