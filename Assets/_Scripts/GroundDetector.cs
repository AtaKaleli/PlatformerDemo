using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Collider2D agentGroundCollider;
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
        if (agentGroundCollider == null)
            agentGroundCollider = GetComponent<Collider2D>();
    }



    public bool CheckIsGrounded()
    {
        RaycastHit2D rayCastHit = Physics2D.BoxCast(agentGroundCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
            new Vector3(boxCastWidth, boxCastHeight, 0), 0, Vector2.down, 0, groundLayer);

        if (rayCastHit.collider != null)
        {
            if(rayCastHit.collider.IsTouching(agentGroundCollider))
                isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        return isGrounded;
    }



    private void OnDrawGizmos()
    {
        if (agentGroundCollider == null)
            return;

        Gizmos.color = gizmoColorNotGrounded;

        if(isGrounded)
            Gizmos.color = gizmoColorIsGrounded;

        Gizmos.DrawWireCube(agentGroundCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0), new Vector3(boxCastWidth, boxCastHeight, 0));
    }


}