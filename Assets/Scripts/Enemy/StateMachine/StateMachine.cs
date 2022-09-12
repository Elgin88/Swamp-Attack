using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private State _firstState;

    private State _currentState;

    private void Start()
    {
        _currentState = _firstState;
        Reset(_firstState);
        StartCoroutine(ChangeState());
    }

    private IEnumerator ChangeState()
    {
        while (true)
        {
            if (_currentState == null)
                yield return null;

            State nextState = _currentState.TryGetNextState();            

            if (nextState != null)
                NextState(nextState);

            yield return null;
        }        
    }

    private void Reset (State fistState)
    {
        if (fistState != null)
            fistState.Enter(_target);
    }

    private void NextState (State nextState)
    {
        if (_currentState != null)        
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }    
}
