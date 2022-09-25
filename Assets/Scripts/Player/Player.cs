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

    private Coroutine _shootWork;
    private Coroutine _shootFromUziWork;
    private Animator _animator;
    private Weapon _currentWeapon;
    private string _idle = "Idle";
    private string _shoot = "Shoot";
    private int _currentHealth;
    private int _currentMoney;
    private int _currentWeaponNumber = 0;
    private int _shoots;

    public int Money => _money;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _maxHealth;
        _currentMoney = _money;
        _currentWeapon = _weapons[_currentWeaponNumber];

        _animator.Play(_idle);

        _shootWork = StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.Play(_shoot);

                if(_currentWeapon.TryGetComponent<Pistol> (out Pistol pistol))
                {
                    _currentWeapon.Shoot(_shootPoint);
                }
                else if (_currentWeapon.TryGetComponent<Uzi>(out Uzi uzi))
                {
                    _shootFromUziWork = StartCoroutine(ShootFromUzi(uzi));
                }
            }            

            yield return null;
        }       
    }

    private IEnumerator ShootFromUzi(Uzi uzi)
    {
        while (true)
        {
            if (_shoots == uzi.NumberBullets)          
            {
                _shoots = 0;
                StopCoroutine(_shootFromUziWork);            
            }

            _shoots++;
            _currentWeapon.Shoot(_shootPoint);

            yield return new WaitForSeconds(uzi.DelayBetweenBullets);
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

    public void NextWeapon()
    {
        if (_currentWeaponNumber <  _weapons.Count)
        {
            _currentWeaponNumber++;
            _currentWeapon = _weapons[_currentWeaponNumber];
        }
        else
        {
            _currentWeaponNumber = 0;
            _currentWeapon = _weapons[_currentWeaponNumber];
        }        
    }
}
