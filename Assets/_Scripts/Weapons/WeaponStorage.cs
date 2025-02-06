using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WeaponSystem
{
    //this will  be a helper script, it will help us organize our weapons instead of keeping the weapon data inside our manager
    public class WeaponStorage
    {

        private List<WeaponData> weaponDataList = new List<WeaponData>();
        private int currentWeaponIndex = -1;

        public int WeaponCount { get => weaponDataList.Count; }



        public WeaponData GetCurrentWeapon()
        {
            if (currentWeaponIndex == -1)
                return null;

            return weaponDataList[currentWeaponIndex];
        }

        public WeaponData SwapWeapon()
        {
            if (currentWeaponIndex == -1)
                return null;

            currentWeaponIndex++;

            if(currentWeaponIndex == weaponDataList.Count)
            {
                currentWeaponIndex = 0;
            }

            return weaponDataList[currentWeaponIndex];
        }

        public bool AddWeapon(WeaponData newWeapon)
        {
            if (weaponDataList.Contains(newWeapon))
                return false;

            weaponDataList.Add(newWeapon);
            currentWeaponIndex = weaponDataList.Count - 1;
            return true;
        }

        public List<string> GetPlayerWeaponNames()
        {
            return weaponDataList.Select(weapon => weapon.name).ToList();
        }

    }
}