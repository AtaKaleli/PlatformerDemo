using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.AI
{
    public class AIMeleeAttackDetector : MonoBehaviour
    {
        public bool PlayerDetected { get; private set; }

        public LayerMask playerLayerMask;
        public float radius;

        [Header("Gizmo Parameters")]
        public Color attackDetectorColor = Color.green;
        public bool showGizmos;


        private void Update()
        {
            MeleeAttackCheck();
        }

        private void MeleeAttackCheck()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius,playerLayerMask);
            PlayerDetected = collider != null;

        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = attackDetectorColor;
                Gizmos.DrawWireSphere(transform.position, radius);
            }
        }


    }
}