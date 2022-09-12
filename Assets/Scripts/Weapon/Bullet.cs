using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 30;
    [SerializeField] private int _damage = 10;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy> (out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
}