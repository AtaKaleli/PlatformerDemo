 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private List<LifeElementUI> healthImages;

    [SerializeField] private Sprite fullHeart, emptyHeart;
    [SerializeField] private LifeElementUI healthPrefab;


    public void Initialize(int maxHealth)
    {
        healthImages = new List<LifeElementUI>();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth; i++)
        {
            var life = Instantiate(healthPrefab);
            life.transform.SetParent(transform, false);
            healthImages.Add(life);
        }
    }

    public void SetHealths(int currentHealth)
    {
        print(currentHealth);
        for (int i = 0; i < healthImages.Count; i++)
        {
            if(i < currentHealth)
            {
                print("full: " + i);
                healthImages[i].SetSprite(fullHeart);
            }
            else
            {
                print("empty: " + i);
                healthImages[i].SetSprite(emptyHeart);
            }
        }
    }

  
}
