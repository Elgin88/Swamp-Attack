using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private int _numberBullets;
    [SerializeField] private float _delay;

    private Transform _shootPoint;
    private WaitForSeconds _shotDelay;
    private Coroutine _shootFromUzi;
    private int _shootBullets;

    public override void Shoot(Transform shootPoint)
    {
        _shootPoint = shootPoint;
        _shotDelay = new WaitForSeconds(_delay);
        _shootFromUzi = StartCoroutine(ShootFromUzi());
        Debug.Log("2");
    }

    private IEnumerator ShootFromUzi()
    {
        Debug.Log("3");
        while (_shootBullets != _numberBullets)
        {
            Instantiate(Bullet, _shootPoint.transform.position, Quaternion.identity);
            _shootBullets++;
            yield return _shotDelay;
        }

        StopCoroutine(_shootFromUzi);
        
        yield return null;
    }
}
