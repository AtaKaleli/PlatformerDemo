using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class Damagable : MonoBehaviour, IHittable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public UnityEvent<int> OnHealthValueChange;

    public UnityEvent<int> OnInitializeMaxHealth;

    public UnityEvent OnGetHit;
    public UnityEvent OnDie;
    public UnityEvent OnAddHealth;

    
    public int CurrentHealth 
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            OnHealthValueChange?.Invoke(currentHealth);
        }
    }

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        CurrentHealth -= weaponDamage;

        if(CurrentHealth <= 0)
        {
            OnDie?.Invoke();
        }
        else
        {
            OnGetHit?.Invoke();
        }
    }

    public void AddHealth(int val)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + val, 0, maxHealth);
        OnAddHealth?.Invoke();
    }

    public void InitializeHealth(int health)
    {
        maxHealth = health;
        OnInitializeMaxHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
    }

}
