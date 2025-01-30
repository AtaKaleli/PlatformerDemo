using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private HealthUI healthUI;
    private PointUI pointUI;



    private void Awake()
    {
        healthUI = GetComponentInChildren<HealthUI>();
        pointUI = GetComponentInChildren<PointUI>();
    }



    public void InitializeHealth()
    {
        healthUI.Initialize();
    }

    public void SetHealth(int currentHealth)
    {
        healthUI.SetHealths(currentHealth);
    }

    public void SetPoint(int currentPoint)
    {
        pointUI.SetPoint(currentPoint);
    }

}
