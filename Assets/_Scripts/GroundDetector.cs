using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Collider2D groundCollider;
    [SerializeField] private LayerMask groundLayer;


    [Header("Gizmo Information")]
    [Range(-2f,2f)]
    [SerializeField] private float boxCastXOffset = 0.5f;
    [Range(-2f, 2f)]
    [SerializeField] private float boxCastYOffset = 0.5f;
    [Range(0f, 2f)]
    [SerializeField] private float boxCastWidth = 1f;
    [Range(0f, 2f)]
    [SerializeField] private float boxCastHeight = 1f;

    [SerializeField] private Color gizmoColorIsGrounded = Color.green;
    [SerializeField] private Color gizmoColorNotGrounded = Color.red;

    private bool isGrounded;


    private void Awake()
    {
        if (groundCollider == null)
            groundCollider = GetComponent<Collider2D>();
    }



    public bool CheckIsGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(groundCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
            new Vector3(boxCastWidth, boxCastHeight, 0), 0, Vector2.down, 0, groundLayer);

        if (rayCastHit)
        {
            return true;
        }

        return false;
    }



    private void OnDrawGizmos()
    {
        if (groundCollider == null)
            return;

        Gizmos.color = gizmoColorNotGrounded;

        if(isGrounded)
            Gizmos.color = gizmoColorIsGrounded;

        Gizmos.DrawWireCube(groundCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0), new Vector3(boxCastWidth, boxCastHeight, 0));
    }


}