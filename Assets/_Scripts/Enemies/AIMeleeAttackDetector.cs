using UnityEngine;
using UnityEngine.Events;

namespace MG.AI
{
    public class AIMeleeAttackDetector : MonoBehaviour
    {
        public bool PlayerDetected { get; private set; }

        public LayerMask playerLayerMask;

        public UnityEvent<GameObject> OnPlayerDetected;

        [Header("Gizmo parameters")]
        public float radius;
        public Color gizmoColor = Color.green;
        public bool showGizmos = true;



        private void Update()
        {
            var collider = Physics2D.OverlapCircle(transform.position, radius, playerLayerMask);

            PlayerDetected = collider != null;

            if (PlayerDetected)
            {
                OnPlayerDetected?.Invoke(collider.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawWireSphere(transform.position, radius);
            }

        }




    }
}