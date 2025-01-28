using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
    die,
    hit,
    idle,
    attack,
    run,
    jump,
    fall,
    climb,
    land
}


public class AgentAnimation : MonoBehaviour
{
    private Animator anim;



    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.die:
                break;
            case AnimationType.hit:
                break;
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.attack:
                break;
            case AnimationType.run:
                Play("Run");
                break;
            case AnimationType.jump:
                Play("Jump");
                break;
            case AnimationType.fall:
                Play("Fall");
                break;
            case AnimationType.climb:
                Play("Climb");
                break;
            case AnimationType.land:
                break;
            default:
                break;
        }
    }


    private void Play(string name)
    {
        anim.Play(name, -1, 0f);
    }

}

