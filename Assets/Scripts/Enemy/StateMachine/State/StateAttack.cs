using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBeetweenAttack;

    private Coroutine _attackWork;
    private Animator _animator;
    private WaitForSeconds _delay;
    private string _attack = "Attack";

    private void Start()
    {
        enabled = false;        
    }

    private void OnEnable()
    {
        _attackWork = StartCoroutine(Attack());
        _animator = GetComponent<Animator>();
        _delay = new WaitForSeconds(_delayBeetweenAttack);
    }

    private void OnDisable()
    {
        StopCoroutine(_attackWork);
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            _animator.Play(_attack);
            Target.ApplyDamage(_damage);
            yield return _delay;
        }       
    }
}
