using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private int _numberBullets;
    [SerializeField] private float _delayBetweenBullets;

    public int NumberBullets => _numberBullets;
    public float DelayBetweenBullets => _delayBetweenBullets;

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);
    }    
}
