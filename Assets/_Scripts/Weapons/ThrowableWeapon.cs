using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class ThrowableWeapon : MonoBehaviour
    {
        private Vector2 startPosition = Vector2.zero;
        private Vector2 movemomentDirection;
        private RangeWeaponData data;
        private bool isInitialized;
        private Rigidbody2D rb;
        private Transform spriteTransform;
        
        [SerializeField] private float rotationSpeed;


        [Header("Collision Detection Data")]
        [SerializeField] private Vector2 center = Vector2.zero;

        [SerializeField]
        [Range(0.1f, 2f)]
        private float radius;

        [SerializeField] private Color gizmoColor = Color.red;
        private LayerMask layerMask;



        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteTransform = transform.GetChild(0);
        }

        private void Start()
        {
            startPosition = transform.position;
        }

        private void Update()
        {
            if (isInitialized)
            {
                RotateProjectile();
                DetectCollision();

                if(((Vector2)transform.position - startPosition).magnitude >= data.attackRange) // destroy throwable if it goes beyond the attack range
                {
                    Destroy(gameObject);
                }
            }
        }

        private void DetectCollision()
        {
            Collider2D collision = Physics2D.OverlapCircle((Vector2)transform.position + center, radius, layerMask);
            if(collision != null)
            {
                foreach (var hittable in collision.GetComponents<IHittable>())
                {
                    hittable.GetHit(gameObject, data.weaponDamage);
                }
                Destroy(gameObject);
            }
        }

        private void RotateProjectile()
        {
            spriteTransform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * rotationSpeed * -movemomentDirection.x);
        }

        public void Initialize(RangeWeaponData data, Vector2 direction, LayerMask mask)
        {
            this.data = data;
            this.movemomentDirection = direction;
            this.layerMask = mask;

            isInitialized = true;
            rb.velocity = movemomentDirection * data.weaponThrowSpeed;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position + (Vector3)center, radius);
        }







    }
}