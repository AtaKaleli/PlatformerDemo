
using UnityEngine;



public enum StateType
{
    Idle,
    Move,
    Jump,
    Fall,
    Climb,
    Attack,
    GetHit,
    Die
}




public class StateFactory : MonoBehaviour
{
    [SerializeField]
    private State Idle, Move, Jump, Fall, Climb, Attack, GetHit, Die;



    public State GetState(StateType stateType) => stateType switch
    {
        StateType.Idle => Idle,
        StateType.Move => Move,
        StateType.Jump => Jump,
        StateType.Fall => Fall,
        StateType.Climb => Climb,
        StateType.Attack => Attack,
        StateType.GetHit => GetHit,
        StateType.Die => Die,
        _ => throw new System.Exception("State not defined " + stateType.ToString())
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

