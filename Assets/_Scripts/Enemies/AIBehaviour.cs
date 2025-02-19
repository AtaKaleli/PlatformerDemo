using UnityEngine;

namespace MG.AI
{
    public abstract class AIBehaviour : MonoBehaviour
    {
        public abstract void PerformBehaviour(AIEnemyInput enemyAI);
    }
}