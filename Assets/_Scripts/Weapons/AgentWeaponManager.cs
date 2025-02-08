using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    //to help our attack state to get the reference of our weapon
    public class AgentWeaponManager : MonoBehaviour
    {
        

        private SpriteRenderer sr; 
        private WeaponStorage weaponStorage; // not a monobehaviour, just contains list of our weapon data referances

        public UnityEvent<Sprite> OnWeaponSwap; 
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnWeaponPickUp;

        [SerializeField] private WeaponData club;

        private void Awake()
        {
            weaponStorage = new WeaponStorage();
            sr = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
        }

        private void Start()
        {
            weaponStorage.AddWeapon(club); 
        }

        public void ToggleWeaponVisibility(bool value)
        {
            if (value)
            {
                SwapWeaponSprite(GetCurrentWeapon().weaponSprite);
            }

            sr.enabled = value;
        }
        

        public void SwapWeapon()
        {
            if (weaponStorage.WeaponCount <= 0)
                return;

            SwapWeaponSprite(weaponStorage.SwapWeapon().weaponSprite);
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

        public void PickUpWeapon(WeaponData newWeapon)
        {
            AddWeapon(newWeapon);
            OnWeaponPickUp?.Invoke();
        }

        public void AddWeapon(WeaponData newWeapon)
        {
            if (!weaponStorage.AddWeapon(newWeapon))
                return;

            if(weaponStorage.WeaponCount > 1) // if we have more that one weapon
            {
                OnMultipleWeapons?.Invoke();
            }
            
            SwapWeaponSprite(newWeapon.weaponSprite);
            
            

        }

        public bool CanIUseWeapon(bool isGrounded)
        {
            if (weaponStorage.WeaponCount <= 0) // this means player does not have any weapon
                return false;

            return weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames()
        {
            return weaponStorage.GetPlayerWeaponNames();
        }










    }
}