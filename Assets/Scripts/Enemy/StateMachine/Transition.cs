using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    public State NextState => _nextState;

    public Player Target { get; private set; }

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    public void StartTransitWork()
    {
        StartCoroutine(TransitionWork());
    }

    public void StopTransitWork()
    {
        StopCoroutine(TransitionWork());
    }

    public abstract IEnumerator TransitionWork();



}
