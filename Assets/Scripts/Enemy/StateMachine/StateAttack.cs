using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private float _timeAfterLastAttack;
    private string _attack = "Attack";   

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _timeAfterLastAttack = _delay;
    }

    private void Update()
    {
        if (_timeAfterLastAttack >= _delay)
        {
            _animator.Play(_attack);
            _timeAfterLastAttack = 0;
            Target.ApplyDamage(_damage);
        }

        _timeAfterLastAttack += Time.deltaTime;        
    }

}
