using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _money = 0;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;

    private Animator _animator;
    private Weapon _currentWeapon;
    private string _shoot = "Shoot";
    private string _idle = "Idle";
    private int _currentHealth;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _maxHealth;
        _currentWeapon = _weapons[0];
        
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        _animator.Play(_idle);
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
