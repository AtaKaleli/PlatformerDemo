using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRb2DMovement : MonoBehaviour
{
    private Rigidbody2D rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
    }
}
