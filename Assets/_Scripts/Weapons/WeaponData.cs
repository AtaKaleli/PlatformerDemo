using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public Sprite weaponSprite;


    public bool CanBeUsed(bool isGrounded)
    {
        return isGrounded;
    }
}
