using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDistance : Transition
{
    [SerializeField] private float _transitionDistande;
    [SerializeField] private float _distanceRange;

    public override void StartTransitionWork()
    {
        NeedTransit = false;
        _transitionDistande += Random.Range(-_distanceRange, _distanceRange);
        StartCoroutine(CheckDistance());
    }

    public override void StopTransitionWork()
    {
        StopCoroutine(CheckDistance());        
    }

    private IEnumerator CheckDistance()
    {
        Debug.Log("1");

        while (true)
        {
            Debug.Log("2");

            if (Vector2.Distance(transform.position, Target.transform.position) < _transitionDistande)
            {
                NeedTransit = true;
                Debug.Log("2");
            }
            
            yield return null;
        }
    }
}
