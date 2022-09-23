using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;


    private Coroutine _instantiateEnemyWork;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawned = 0;
    private int _spawnedNumber = 0;
    private WaitForSeconds _delayBetweenSpawn;

    private void Start()
    {
        _currentWave = _waves[_currentWaveNumber];
        _delayBetweenSpawn = new WaitForSeconds(_currentWave.Delay);
        _instantiateEnemyWork = StartCoroutine (InstantiateEnemy());
    }

    private IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            Enemy enemy = Instantiate(_currentWave.Template[_spawnedNumber], transform.position, Quaternion.identity);

            enemy.Init(_target);

            _spawned++;
            _spawnedNumber++;
            _spawnedNumber = Mathf.Clamp(_spawnedNumber, 0, _currentWave.Template.Count - 1);

            if (_currentWave.Count <= _spawned)
                StopCoroutine(_instantiateEnemyWork);            

            yield return _delayBetweenSpawn;
        }
    }
}

[System.Serializable]

public class Wave
{
    public List<Enemy> Template;  
    public int Count;
    public int Delay;
}