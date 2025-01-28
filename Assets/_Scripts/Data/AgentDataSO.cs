using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AgentData",menuName = "Agent/Data" )]
public class AgentDataSO : ScriptableObject
{
    [Header("Movement Data")]
    [Space]
    public float acceleration = 50f;
    public float deacceleration = 50f;
    public float maxSpeed = 6f;

    [Header("Jump Data")]
    [Space]
    public float jumpForce = 12f;
    public float gravityModifier = 2f;

    [Header("Climb Data")]
    [Space]
    public float climbHorizontalSpeed = 2f;
    public float climbVerticalSpeed = 5f;

}
