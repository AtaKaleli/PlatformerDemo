using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlipDetector : MonoBehaviour
{
    public BoxCollider2D detectorCollider; // collisions that enemy might have face

    public LayerMask groundLayerMask;
    public float groundRaycastLength;

    [Range(0, 1)]
    public float groundRaycastDelay = 0.1f;

    public bool PathBlocked { get; private set; }

    public event Action OnPathBlocked;


    [Header("Gizmo Parameters")]
    public Color detectorColliderColor = Color.magenta;
    public Color raycastColor = Color.blue;
    public bool showGizmos;


    private void Start()
    {
        StartCoroutine(CheckGroundCoroutine());
    }

    private IEnumerator CheckGroundCoroutine()
    {
        yield return new WaitForSeconds(groundRaycastDelay);

        RaycastHit2D hit = Physics2D.Raycast(detectorCollider.bounds.center, Vector2.down, groundRaycastLength, groundLayerMask);



        if (hit.collider == null)
        {
            OnPathBlocked?.Invoke();
        }

        PathBlocked = hit.collider == null;
        StartCoroutine(CheckGroundCoroutine());
    }



    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPathBlocked?.Invoke();
    }
    */
    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = raycastColor;
            Gizmos.DrawRay(detectorCollider.bounds.center, Vector2.down * groundRaycastLength);
            Gizmos.color = detectorColliderColor;
            Gizmos.DrawWireCube(detectorCollider.bounds.center, detectorCollider.size);
        }
    }



}
