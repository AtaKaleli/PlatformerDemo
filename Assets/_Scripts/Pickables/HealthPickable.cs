using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pickable
{
    public class HealthPickable : Pickable
    {

        [SerializeField] private int healthBoost = 1;

        public override void PickUp(Agent player)
        {
            Damagable damagable = player.GetComponent<Damagable>();
            if(damagable == null) { return; }

            damagable.AddHealth(healthBoost);
        }
    }
}