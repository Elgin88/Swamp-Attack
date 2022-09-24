using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player target))
        {
            target.ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
