using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage : MonoBehaviour
{
    private List<WeaponData> weaponData;

    private WeaponData currentWeapon;
    private WeaponData nextWeapon;

    public int WeaponCount { get; set; }


    private void Awake()
    {
        weaponData = new List<WeaponData>();
    }


    public WeaponData GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public WeaponData SwapWeapon()
    {
        return nextWeapon;
    }

    public void AddWeaponData(WeaponData newWeapon)
    {
        weaponData.Add(newWeapon);
    }

    public List<string> GetPlayerWeaponNames()
    {
        throw new System.Exception("sdf");
    }
}
