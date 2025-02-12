using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour, IHittable
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public UnityEvent OnGetHit;
    public UnityEvent OnDie;
    public UnityEvent OnAddHealth;

    public UnityEvent<int> OnInitializeMaxHealth;
    public UnityEvent<int> OnDetectCurrentHealth;


    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = value;
            OnDetectCurrentHealth?.Invoke(currentHealth);
        }
    }







    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        CurrentHealth -= weaponDamage;

        if(currentHealth <= 0)
        {
            OnDie?.Invoke();
        }
        else
        {
            OnGetHit?.Invoke();
        }
    }

    public void InitializeMaxHealth(int value)
    {
        maxHealth = value;
        OnInitializeMaxHealth?.Invoke(maxHealth);
        CurrentHealth = maxHealth;
    }

    public void AddHealth(int value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, maxHealth);
        OnAddHealth?.Invoke();
    }





}
