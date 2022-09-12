using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Coroutine _stateWork;
    
    public Player Target { get; private set; }

    public void Enter(Player target)
    {
        Target = target;
        _stateWork = StartCoroutine(StateWork());

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

        StopCoroutine(_stateWork);
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

    public abstract IEnumerator StateWork();
}
