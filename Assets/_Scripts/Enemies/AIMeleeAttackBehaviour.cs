using System.Collections;
using UnityEngine;

namespace MG.AI
{
    public class AIMeleeAttackBehaviour : AIBehaviour
    {

        public AIMeleeAttackDetector meleeRangeDetector;

        [SerializeField] private bool isWaiting;
        [SerializeField] private float delay = 1f;




        private void Awake()
        {
            if (meleeRangeDetector == null)
                meleeRangeDetector = GetComponentInParent<AIMeleeAttackDetector>();
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting) { return; }
            if (meleeRangeDetector.PlayerDetected == false) { return; }

            enemyAI.CallOnAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());

        }



        private IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }

    }
}