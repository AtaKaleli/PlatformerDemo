using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapons/MeleeWeaponData")]
    public class MeleeWeaponData : WeaponData
    {
        public float attackRange;


        public override bool CanBeUsed(bool isGrounded)
        {
            return isGrounded;
        }
        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(agent.agentWeapon.transform.position, direction, attackRange, hittableMask);
            
            if(hit.collider != null)
            {
   
                foreach (var hittable in hit.collider.GetComponents<IHittable>())
                {

                    hittable.GetHit(agent.gameObject, weaponDamage);
                }
            }
        }

 


    }
}