using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TransitionTargetDie : Transition
{
    public override IEnumerator TransitionWork()
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
