using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public Player Target { get; private set; }

    private void Start()
    {
        enabled = false;          
    }

    public void Enter(Player target)
    {
        enabled = true;
        Target = target;        

        foreach (Transition transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(Target);
        }
    }

    public void Exit()
    {
        foreach (Transition transition in _transitions)
        {
            transition.enabled = false;
        }

        enabled = false;
    }

    public State TryGetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.NextState;
            }
        }

        return null;
    }
}
