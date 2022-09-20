using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenAttack;
    [SerializeField] private float _delayAnimation;

    private WaitForSeconds _delayBetweenAttackWFS;
    private WaitForSeconds _delayAnimationWFS;
    private Animator _animator;
    private string _attack = "Attack";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _delayBetweenAttackWFS = new WaitForSeconds(_delayBetweenAttack);
        _delayAnimationWFS = new WaitForSeconds(_delayAnimation);
    }

    public override IEnumerator StateWork()
    {
        while (true)
        {
            _animator.Play(_attack);

            yield return _delayAnimationWFS;

            Target.ApplyDamage(_damage);

            yield return  _delayBetweenAttackWFS;
        }
    }
}
