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
                break;
            case AnimationType.fall:
                break;
            case AnimationType.climb:
                break;
            case AnimationType.land:
                break;
            default:
                break;
        }
    }

    public void Play(string name) // play custom animations for specific cases
    {
        anim.Play(name, -1, 0f);
    }


}

