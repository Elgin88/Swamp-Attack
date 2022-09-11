using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _money = 0;    
    [SerializeField] private List<Weapon> _weapons;

    private Transform _shootPoint;
    private Animator _animator;
    private Weapon _currentWeapon;
    private string _shoot = "Shoot";
    private string _idle = "Idle";
    private int _currentHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _shootPoint = GetComponentInChildren<ShootPoint>().transform;

        _currentHealth = _maxHealth;
        _currentWeapon = _weapons[0];

        _animator.Play(_idle);

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.Play(_shoot);
                _currentWeapon.Shoot(_shootPoint);
            }

            yield return null;           
        }       
    }
}
