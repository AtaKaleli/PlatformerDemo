using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.AI
{
    public class AIEndPlatformDetector : MonoBehaviour
    {

        public BoxCollider2D detectorCollider; //responsible for detecting the collision between the obstacles that might be face with enemy

        public LayerMask groundMask;
        public float groundRaycastLength = 2;

        [Range(0, 1)]
        public float groundRaycastDelay = 0.1f;

        public bool PathBlocked { get; private set; }

        public event Action OnPathBlocked;


        [Header("Gizmo Parameters")]
        public Color colliderColor = Color.magenta;
        public Color groundRaycastColor = Color.blue;
        public bool showGizmos = true;


        private void Start()
        {
            StartCoroutine(CheckGroundCoroutine());

        }

        private IEnumerator CheckGroundCoroutine()
        {
            yield return new WaitForSeconds(groundRaycastDelay);
            
            var hit = Physics2D.Raycast(detectorCollider.bounds.center, Vector2.down, groundRaycastLength, groundMask);

            if(hit.collider == null) // if there is no ground to detect
            {
                OnPathBlocked?.Invoke();
            }

            PathBlocked = hit.collider == null;
            StartCoroutine(CheckGroundCoroutine()); // recursively call the coroutine
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if(collision.gameObject.layer != LayerMask.NameToLayer("Player"))
                OnPathBlocked?.Invoke(); // we want to inform enemy that we have collided with smt
        }

        private void OnDrawGizmos()
        {
            if(showGizmos && detectorCollider != null)
            {
                Gizmos.color = groundRaycastColor;
                Gizmos.DrawRay(detectorCollider.bounds.center, Vector2.down * groundRaycastLength);
                Gizmos.color = colliderColor;
                Gizmos.DrawCube(detectorCollider.bounds.center, detectorCollider.bounds.size);
            }
        }

    }
}