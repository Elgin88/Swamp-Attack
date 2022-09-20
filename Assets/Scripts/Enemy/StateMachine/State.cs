using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Coroutine _stateWork;
    
    public Player Target { get; private set; }

    public void Enter (Player player)
    {
        Target = player;

        StartStateWork();

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
        
        StopStateWork();      
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

    public void StartStateWork()
    {
        _stateWork = StartCoroutine(StateWork());
    }

    public void StopStateWork()
    {
        StopCoroutine(_stateWork);
    }

    public abstract IEnumerator StateWork();
}
