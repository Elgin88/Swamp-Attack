using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateAttack : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBeetweenAttack;

    private WaitForSeconds _delay;    

    private Animator _animator;
    private string _attack = "Attack";    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _delay = new WaitForSeconds(_delayBeetweenAttack);
    }

    public override IEnumerator StateWork()
    {
        while (true)
        {
            _animator.Play(_attack);
            Target.ApplyDamage(_damage);
            yield return _delay;
        }  
    }
}
