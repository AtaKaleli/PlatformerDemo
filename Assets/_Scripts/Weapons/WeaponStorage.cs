using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    //this will  be a helper script, it will help us organize our weapons instead of keeping the weapon data inside our manager
    public class WeaponStorage
    {

        private List<WeaponData> weaponDataList;
        public int WeaponCount { get => weaponDataList.Count; }



        public WeaponData GetCurrentWeapon()
        {
            throw new System.Exception("");
        }

        public WeaponData SwapWeapon()
        {
            throw new System.Exception("");
        }

        public void AddWeapon(WeaponData newWeapon)
        {
            throw new System.Exception("");
        }

        public List<string> GetPlayerWeaponNames()
        {
            throw new System.Exception("");
        }

    }
}