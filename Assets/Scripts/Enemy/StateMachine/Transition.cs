using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] State _nextState;

    public Player Target { get; private set; }
    public bool NeedTransit { get; protected set; }
    public State NextState => _nextState;

    public void Init (Player target)
    {
        Target = target;
    }

    public abstract void StartTransitionWork();
    public abstract void StopTransitionWork();
}
