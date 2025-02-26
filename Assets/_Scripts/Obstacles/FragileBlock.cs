using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FragileBlock : MonoBehaviour, IHittable
{
    public UnityEvent OnHit;

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        OnHit?.Invoke();
    }

    public void DestroySelfAnimationEvent()
    {
        Destroy(gameObject);
    }
}
