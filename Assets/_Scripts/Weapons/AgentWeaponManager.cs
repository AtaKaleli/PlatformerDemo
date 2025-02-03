using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

namespace WeaponSystem
{
    public class AgentWeaponManager : MonoBehaviour
    {


        

        private WeaponStorage weaponStorage;
        private SpriteRenderer sr;

        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapons; // tip on how to swap weapons
        public UnityEvent OnWeaponPickUp;


        private void Awake()
        {
            weaponStorage = new WeaponStorage();
            sr = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
        }

        private void ToggleWeaponVisibility(bool value)
        {
            if (value)
            {
                SwapWeaponSprite(GetCurrentWeapon().weaponSprite);
            }
            sr.enabled = value;
        }

       
        private void SwapWeaponSprite(Sprite weaponSprite)
        {
            sr.sprite = weaponSprite;
            OnWeaponSwap?.Invoke(weaponSprite);
        }

        public WeaponData GetCurrentWeapon()
        {
            return weaponStorage.GetCurrentWeapon();
        }

        public void SwapWeapon()
        {
            if(weaponStorage.WeaponCount <= 0)
            {
                return;
            }
            SwapWeaponSprite(weaponStorage.SwapWeapon().weaponSprite);

        }


        public void PickUpWeapon(WeaponData newWeapon)
        {
            AddWeaponData(newWeapon);
            OnWeaponPickUp?.Invoke(); // weapon pick up audio feedback
        }

        public void AddWeaponData(WeaponData newWeapon)
        {
            weaponStorage.AddWeaponData(newWeapon);

            if(weaponStorage.WeaponCount > 1) // having more than one weapon
            {
                OnMultipleWeapons?.Invoke();
            }

            SwapWeaponSprite(newWeapon.weaponSprite);
        }

        public bool CanUseWeapon(bool isGrounded) // melee attack cant be performed when we are on air
        {
            if(weaponStorage.WeaponCount <= 0)
            {
                return false;
            }
            return weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames() // for save system
        {
            return weaponStorage.GetPlayerWeaponNames();
        }
















    }

}
