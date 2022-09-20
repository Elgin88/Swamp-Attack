using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateCelebration : State
{
    private Animator _animator;
    private string _celabration = "Celebration";

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override IEnumerator StateWork()
    {
        while (true)
        {
            _animator.Play(_celabration);
            yield return null;

        }
    }
}
