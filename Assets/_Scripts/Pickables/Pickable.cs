using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pickable
{
    public abstract class Pickable : MonoBehaviour
    {
        protected SpriteRenderer sr;

        [SerializeField] protected Color gizmoColor = Color.magenta;
        [SerializeField] private BoxCollider2D pickableCollider;


        private void Awake()
        {
            sr = GetComponentInChildren<SpriteRenderer>();
            pickableCollider = GetComponent<BoxCollider2D>();
        }

        public abstract void PickUp(Agent player);


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PickUp(collision.GetComponent<Agent>());
                Destroy(gameObject);
            }
        }

        //to draw gizmos, collider must be serializefield, otherwise it gives error
        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(pickableCollider.bounds.center, pickableCollider.bounds.size);
        }
    }
}