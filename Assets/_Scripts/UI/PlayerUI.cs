using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private HealthUI healthUI;
    private PointsUI pointsUI;



    private void Awake()
    {
        healthUI = GetComponentInChildren<HealthUI>();
        pointsUI = GetComponentInChildren<PointsUI>();
    }

    public void InitializeMaxHealth(int maxHealth)
    {
        healthUI.InitializeHealth(maxHealth);
    }

    public void SetCurrentHealth(int currentHealth)
    {
        healthUI.SetHealth(currentHealth);
    }

    public void SetCurrentPoints(int currentPoints)
    {
        pointsUI.SetPoint(currentPoints);
    }



}
