using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RespawnSystem;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private LayerMask fallenObjectLayerMask;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(fallenObjectLayerMask == 1 << collision.gameObject.layer)
        {
            Agent agent = collision.GetComponent<Agent>();

            if(agent == null)
            {
                Destroy(gameObject);
                return;
            }

            agent.AgentDied();

        }
    }
}
