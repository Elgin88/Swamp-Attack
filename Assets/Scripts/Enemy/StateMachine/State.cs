using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public Player Target { get; private set; }

    public abstract void StartStateWork();
    public abstract void StopStateWork();

    public void Enter(Player target)
    {
        Target = target;

        StartStateWork();

        foreach (var transition in _transitions)
        {
            transition.StartTransitionWork();
            transition.Init(Target);
        }
    }

    public void Exit()
    {
        foreach (var transition in _transitions)
        {
            transition.StopTransitionWork();
        }

        StopStateWork();
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
