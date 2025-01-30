using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private List<LifeElementUI> healths;

    [SerializeField] private Sprite fullHeart, emptyHeart;



    public void Initialize()
    {
        healths = new List<LifeElementUI>();

        foreach (Transform life in transform)
        {
            healths.Add(life.GetComponent<LifeElementUI>());
        }
    }

    public void SetHealths(int currentHealth)
    {
        for (int i = 0; i < healths.Capacity; i++)
        {
            if(i < currentHealth)
            {
                healths[i].SetSprite(fullHeart);
            }
            else
            {
                healths[i].SetSprite(emptyHeart);
            }
        }
    }

  
}
