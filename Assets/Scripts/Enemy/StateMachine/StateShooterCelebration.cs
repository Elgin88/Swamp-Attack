using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateShooterCelebration : State
{
    private Animator _animator;
    private string _celebration = "Celebration";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override IEnumerator StateWork()
    {
        _animator.Play(_celebration);

        yield return null;
    }
}
