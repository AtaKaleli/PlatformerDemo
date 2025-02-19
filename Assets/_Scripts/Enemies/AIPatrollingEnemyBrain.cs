using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.AI
{
    public class AIPatrollingEnemyBrain : AIEnemyInput
    {
        public GroundDetector agentGroundDetector;

        public AIBehaviour patrolBehaviour, attackBehaviour;



        private void Awake()
        {
            if(agentGroundDetector == null)
                agentGroundDetector = GetComponentInChildren<GroundDetector>();
        }

        private void Update()
        {
            if (agentGroundDetector.CheckIsGrounded())
            {

                attackBehaviour.PerformBehaviour(this);
                patrolBehaviour.PerformBehaviour(this);
            }
        }


    }
}