using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    private TextMeshProUGUI pointText;



    private void Awake()
    {
        pointText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetPoint(int val)
    {
        pointText.text = val.ToString("###");
    }
}
