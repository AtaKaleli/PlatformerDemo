using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.AI
{
    public class AIPatrollingEnemyBrain : AIEnemy
    {
        public GroundDetector agentGroundDetector;

        public AIBehaviour attackBehaviour, patrolBehaviour;


        private void Awake()
        {
             if(agentGroundDetector == null)
                agentGroundDetector = GetComponentInChildren<GroundDetector>();
        }

        private void Update()
        {
            if (agentGroundDetector.CheckIsGrounded())
            {
                attackBehaviour.PerformAction(this);
                patrolBehaviour.PerformAction(this);
            }
        }
    }
}