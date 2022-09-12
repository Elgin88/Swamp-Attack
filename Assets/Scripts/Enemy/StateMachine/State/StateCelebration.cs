using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateCelebration : State
{
    public override IEnumerator StateWork()
    {
        while (true)
        {
            yield return null;
        }
    }
}
