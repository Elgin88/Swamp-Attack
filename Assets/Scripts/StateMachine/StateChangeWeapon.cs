using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateChangeWeapon : State
{
    private Animator _animator;
    private string _changeWeapon = "ChangeWeapon";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override IEnumerator StateWork()
    {
        _animator.Play(_changeWeapon);

        yield return null;               
    }
}
