using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDistance : Transition
{
    [SerializeField] private float _transitionDistande;
    [SerializeField] private float _distanceRange;

    private void Start()
    {
        _transitionDistande += Random.Range(- _distanceRange, _distanceRange);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionDistande)
        {
            NeedTransit = true;
        }
    }
}
