using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.Feedback
{
    public class HittableTempImmortality : MonoBehaviour, IHittable
    {
        private CapsuleCollider2D agentCollider;
        private SpriteRenderer sr;
        
        [SerializeField] private float immortalityTimeAmount = 1.5f;

        [Header("Flash Feedback")]
        [SerializeField] private float flashDelay = 0.1f;
        [SerializeField] private float flashAlpha = 0.5f;

        

        private void Awake()
        {
            agentCollider = GetComponent<CapsuleCollider2D>();
            sr = GetComponentInChildren<SpriteRenderer>();
        }


        public void GetHit(GameObject opponent, int weaponDamage)
        {
            StartCoroutine(ResetCollider());
            StartCoroutine(FlashSprite(flashAlpha));
            ToggleCollider(false);

        }

        private void ToggleCollider(bool val)
        {
            agentCollider.enabled = val;
        }

        private IEnumerator ResetCollider()
        {
            yield return new WaitForSeconds(immortalityTimeAmount);
            StopAllCoroutines();
            ToggleCollider(true);
            ChangeSpriteAlpha(1f);
        }

        private void ChangeSpriteAlpha(float alpha)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        }

        private IEnumerator FlashSprite(float alpha)
        {
            while (true)
            {
                ChangeSpriteAlpha(alpha);
                yield return new WaitForSeconds(flashDelay);
                ChangeSpriteAlpha(1f);
                yield return new WaitForSeconds(flashDelay);
            }
        }


        
    }
}