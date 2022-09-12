using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTargetDie : Transition
{
    private Coroutine _checkDieWork;

    private void Start()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _checkDieWork = StartCoroutine(CheckDie());
    }

    private void OnDisable()
    {
        StopCoroutine(_checkDieWork);        
    }

    public IEnumerator CheckDie()
    {
        while (true)
        {
            if (Target == null)
            {
                NeedTransit = true;
            }

            yield return null;
        }
    }
}
