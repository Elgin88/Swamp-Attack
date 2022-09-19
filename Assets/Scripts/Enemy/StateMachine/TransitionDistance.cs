using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDistance : Transition
{
    public override IEnumerator TransitionWork()
    {
        while (true)
        {
            yield return null;
        }
    }
}
