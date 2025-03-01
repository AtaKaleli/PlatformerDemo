using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

namespace WeaponSystem
{
    //hold data of weapons
    public abstract class WeaponData : ScriptableObject
    {

        public string weaponName;
        public Sprite weaponSprite;
        public int weaponDamage;
        public AudioClip weaponSwingSound;
        public float attackRange;



        public abstract bool CanBeUsed(bool isGrounded);
        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
            
        }


        
    }
}