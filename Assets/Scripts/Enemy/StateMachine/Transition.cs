using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    private Coroutine _transitionWork;

    public State NextState => _nextState;

    public Player Target { get; private set; }

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    public void StartTransitWork()
    {
        NeedTransit = false;

        _transitionWork = StartCoroutine(TransitionWork());
    }

    public void StopTransitWork()
    {
        StopCoroutine(_transitionWork);
    }

    public abstract IEnumerator TransitionWork();
}
