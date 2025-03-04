using System.Collections;
using System.Collections.Generic;
using Pickables;
using UnityEngine;
using WeaponSystem;

public class WeaponPickable : Pickable
{
    [SerializeField] private WeaponData weaponData;



    private void Start()
    {
        sr.sprite = weaponData.weaponSprite;
    }


    public override void PickUp(Agent player)
    {
        player.PickUp(weaponData);
    }

    
}
