using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public Player Target { get; private set; }

    public void Enter(Player target)
    {
        enabled = true;
        Target = target;

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(Target);
        }
    }

    public void Exit()
    {
        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }

        enabled = false;
    }

    public State TryGetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit == true)
            {
                return transition.NextState;
            }
        }

        return null;
    }
}
