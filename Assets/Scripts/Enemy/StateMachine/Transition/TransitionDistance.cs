using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDistance : Transition
{
    [SerializeField] private float _distanceRange;
    [SerializeField] private float _rangeSpred;

    private void OnEnable()
    {
        NeedTransit = false;
        _distanceRange += Random.Range(-_rangeSpred, _rangeSpred);

        _checkDistanceJob = StartCoroutine(CheckDistance());
    }

    private void OnDisable()
    {
        StopCoroutine(_checkDistanceJob);        
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) <= _distanceRange)
            {
                NeedTransit = true;
            }

            yield return null;
        }
    }
}
