using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private string _attack = "Attack";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void StartStateWork()
    {
        StartCoroutine(Attack());
    }

    public override void StopStateWork()
    {
        StopCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            _animator.Play(_attack);
            Target.ApplyDamage(_damage);

            yield return new WaitForSeconds(_delay);
        }
    }
}
