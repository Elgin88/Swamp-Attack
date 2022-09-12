using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateCelebration : State
{
    private Animator _animator;
    private string _celebration = "Celebration";

    private void Start()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(_celebration);      
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
