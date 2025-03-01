using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapons/RangeWeaponData")]
    public class RangeWeaponData : WeaponData
    {
        public int weaponThrowSpeed = 1;

        public GameObject rangeWeaponPrefab;





        public override bool CanBeUsed(bool isGrounded)
        {
            return true; // to be able to shoot even player is not grounded
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            agent.agentWeapon.ToggleWeaponVisibility(false);
            GameObject throwable = Instantiate(rangeWeaponPrefab, agent.transform.position, Quaternion.identity);
            throwable.GetComponent<ThrowableWeapon>().Initialize(this, direction, hittableMask);
        }
    }
}