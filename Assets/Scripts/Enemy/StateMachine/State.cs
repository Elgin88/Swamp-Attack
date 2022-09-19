using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;    
    
    public Player Target { get; private set; }

    public void Enter (Player player)
    {
        Target = player;

        foreach (var transition in _transitions)
        {
            transition.Init(Target);
            transition.StartTransitWork();
        }
    }

    public void Exit()
    {
        foreach (var transition in _transitions)
        {
            transition.StopTransitWork();
        }
    }

    public State TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.NextState;
            }
        }

        return null;
    }
}
