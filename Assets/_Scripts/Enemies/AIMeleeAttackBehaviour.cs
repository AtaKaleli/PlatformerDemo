using System.Collections;
using UnityEngine;

namespace MG.AI
{
    public class AIMeleeAttackBehaviour : AIBehaviour
    {
        [SerializeField] private AIMeleeAttackDetector meleeAttackDetector;

        [SerializeField] private float delayBeforeAttack = 1.5f;
        private bool isWaiting;






        public override void PerformBehaviour(AIEnemyInput enemyAI)
        {
            if (isWaiting || meleeAttackDetector.PlayerDetected == false) { return; } // if we are waiting or player is not detected, then return

            enemyAI.CallOnAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());
        }

        private IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delayBeforeAttack);
            isWaiting = false;
        }
    }
}