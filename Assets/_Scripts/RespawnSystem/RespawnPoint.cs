using UnityEngine;
using UnityEngine.Events;


namespace RespawnSystem
{
    public class RespawnPoint : MonoBehaviour
    {
        private GameObject player;

        private RespawnPointManager respawnPointManager;


        private void Awake()
        {
            respawnPointManager = GetComponentInParent<RespawnPointManager>();
        }



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SetPlayer(collision);
                respawnPointManager.UpdateRespawnPoint(this);
            }
        }

        private void SetPlayer(Collider2D collision)
        {
            player = collision.gameObject;
        }

        public void RespawnPlayer()
        {
            player.transform.position = this.transform.position;
        }

        public void DisableRespawnPoint()
        {
            GetComponent<Collider2D>().enabled = false;
        }

        public void ResetRespawnPoint()
        {
            GetComponent<Collider2D>().enabled = true;
        }

        
        



    }
}

