using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

namespace WeaponSystem
{
    //hold data of weapons
    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData>
    {

        public string weaponName;
        public Sprite weaponSprite;
        public int weaponDamage;
        public AudioClip weaponSwingSound;




        public abstract bool CanBeUsed(bool isGrounded);
        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
            
        }

        

        public bool Equals(WeaponData other)
        {
            return weaponName == other.weaponName;
        }

        
    }
}