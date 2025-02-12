 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private List<LifeElementUI> healthImages;

    [SerializeField] private Sprite fullHeart, emptyHeart;
    [SerializeField] private LifeElementUI healthPrefab;

    [SerializeField] private GameObject lifePrefab;


    public void InitializeMaxHealth(int maxHealth)

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

        for (int i = 0; i < healthImages.Count; i++)

        {
            if(i < currentHealth)
            {
                healthImages[i].SetSprite(fullHeart);
            }
            else
            {
                healthImages[i].SetSprite(emptyHeart);
            }
        }
    }

  
}
