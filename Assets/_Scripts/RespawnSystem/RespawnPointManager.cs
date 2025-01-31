using System;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnSystem
{
    public class RespawnPointManager : MonoBehaviour
    {
        private List<RespawnPoint> respawnPoints;
        private RespawnPoint currentRespawnPoint;



        private void Awake()
        {
            InitializeRespawnPoints();
        }

        private void InitializeRespawnPoints()
        {
            respawnPoints = new List<RespawnPoint>();

            foreach (Transform point in transform)
            {
                respawnPoints.Add(point.GetComponent<RespawnPoint>());
            }
            currentRespawnPoint = respawnPoints[0];
        }

        
        public void UpdateRespawnPoint(RespawnPoint newRespawnPoint)
        {
            currentRespawnPoint.DisableRespawnPoint();
            currentRespawnPoint = newRespawnPoint;
        }
        

        public void Respawn()
        {
            currentRespawnPoint.RespawnPlayer();
        }
    }

}
