using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTargetDie : Transition
{
    public override void StartTransitionWork()
    {
        StartCoroutine(CheckDied());
        NeedTransit = false;
    }

    public override void StopTransitionWork()
    {
        StopCoroutine(CheckDied());
        NeedTransit = false;
    }

    private IEnumerator CheckDied()
    {
        while (true)
        {
            if (Target == null)
                NeedTransit = true;

            yield return null;
        }
    }
}
