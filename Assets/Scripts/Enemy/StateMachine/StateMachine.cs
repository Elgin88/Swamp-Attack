using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private Player _target;

    private State _currentState;

    private void Start()
    {
        SetFirstState(_firstState);        
        StartCoroutine(TrySetNextState());
    }

    private IEnumerator TrySetNextState()
    {
        while (true)
        {
            if (_currentState == null)
                yield return null;

            State nextState = _currentState.TryGetNextState();

            if (nextState != null)
                Transit(nextState);

            yield return null;
        }
    }

    private void SetFirstState(State firstState)
    {
        _currentState = firstState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();        

        _currentState = nextState;
        
        if (_currentState != null)
            _currentState.Enter(_target);        
    }
}
