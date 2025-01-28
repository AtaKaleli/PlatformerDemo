using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDetector : MonoBehaviour
{
    [SerializeField] private LayerMask climbLayerMask;

    public bool CanClimb { get; private set; }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        LayerMask collisionLayerMask = 1 << collision.gameObject.layer;
        if((collisionLayerMask & climbLayerMask) != 0)
        {
            CanClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LayerMask collisionLayerMask = 1 << collision.gameObject.layer;
        if ((collisionLayerMask & climbLayerMask) != 0)
        {
            CanClimb = false;
        }
    }

}
