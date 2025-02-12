using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private List<LifeElementUI> healths;

    [SerializeField] private Sprite fullHeart, emptyHeart;

    [SerializeField] private GameObject lifePrefab;

    public void InitializeMaxHealth(int maxHealth)
    {
        healths = new List<LifeElementUI>();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth; i++)
        {
            var life = Instantiate(lifePrefab);
            life.transform.SetParent(transform, false);
            healths.Add(life.GetComponent<LifeElementUI>());
        }
    }

    public void SetHealths(int currentHealth)
    {
        for (int i = 0; i < healths.Count; i++)
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
