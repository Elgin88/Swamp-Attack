using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] Transform _shootPoint;

    private int _currentHealth;

    public Player Target { get; private set; }
    public Transform ShootPoint => _shootPoint;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if (_currentHealth == 0)
            Destroy(gameObject);
    }

    public void Init(Player target)
    {
        Target = target;
    }
}
