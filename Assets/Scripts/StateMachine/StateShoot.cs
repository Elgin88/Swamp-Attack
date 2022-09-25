using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class StateShoot : State
{
    [SerializeField] private Weapon _weapon;    
    [SerializeField] private float _delay;

    private WaitForSeconds _delayShoot;
    private Transform _shootPoint;
    private Animator _animator;

    private string _shoot = "Shoot";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _shootPoint = GetComponent<Enemy>().ShootPoint;
        _delayShoot = new WaitForSeconds(_delay);        
    }

    public override IEnumerator StateWork()
    {
        while (true)
        {
            _animator.Play(_shoot);
            _weapon.Shoot(_shootPoint);

            yield return _delayShoot;
        }        
    }
}
