using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum StateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Climb,
    Attack
}


public class StateFactory : MonoBehaviour
{
    [SerializeField]
    private State Idle, Move, Jump, Fall, Climb, Attack;




    public State GetState(StateType stateType) => stateType switch
    {
        StateType.Idle => Idle,
        StateType.Move => Move,
        StateType.Jump => Jump,
        StateType.Fall => Fall,
        StateType.Climb => Climb,
        StateType.Attack => Attack,
        _ => throw new System.Exception("State not defined : " + stateType.ToString())
    };

    public void InitializeStates(Agent agent)
    {
        State[] states = GetComponentsInChildren<State>();
        foreach (var state in states)
        {
            state.InitializeState(agent);
        }
    }





}
