using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandGroundCheck : MonoBehaviour
{
    [SerializeField] private GroundDetector groundDetector;

    public UnityEvent OnConditionValidAction;


    public void TryValidAction()
    {
        if (groundDetector.CheckIsGrounded())
        {
            OnConditionValidAction?.Invoke();
        }
    }
}
