using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _money = 0;

    private Animator _animator;
    private Weapon _currentWeapon;
    private string _idle = "Idle";
    private string _shoot = "Shoot";
    private int _currentHealth;
    private int _currentMoney;

    public int Money => _money;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _maxHealth;
        _currentMoney = _money;
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

    public void TakeMoney (int money)
    {
        _currentMoney += money;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if (_currentHealth == 0)
        {
            Destroy(gameObject);            
        }           
    }

    public void BuyWeapon(Weapon weapon)
    {
        _money -= weapon.Price;
        _weapons.Add(weapon);
    }
}
