using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.Feedback
{
    public class HittableKnockback : MonoBehaviour, IHittable
    {
        private Rigidbody2D rb;
        
        [SerializeField] private float force = 10f;



        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }



        public void GetHit(GameObject opponent, int weaponDamage)
        {
            Vector2 direction = transform.position - opponent.transform.position;
            rb.AddForce(new Vector2(direction.normalized.x, 0) * force, ForceMode2D.Impulse);
        }


    }
}