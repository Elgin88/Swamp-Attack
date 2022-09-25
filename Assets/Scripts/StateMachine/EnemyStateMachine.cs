using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _fistState;

    private State _currentState;
    private Player _target;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;

        SetFirstState(_fistState);
        StartCoroutine(TrySetNextState());
    }

    private void SetFirstState(State firstState)
    {
        _currentState = firstState;

        if (_currentState!= null)
        {
            _currentState.Enter(_target);
        }
    }

    private IEnumerator TrySetNextState()
    {
        while (true)
        {
            State nextState = _currentState.TryGetNextState();

            if (nextState != null)
            {
                Transit(nextState);                
            }

            yield return null;
        }        
    }

    private void Transit (State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
