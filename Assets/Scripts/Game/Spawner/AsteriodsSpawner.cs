using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodsSpawner : Pool
{
    [SerializeField] private GameObject _asteroidPrefub;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Init(_asteroidPrefub);
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGet(out GameObject asteroid))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetEnemy(asteroid, _spawnPoints[spawnPointNumber].position);
                asteroid.GetComponent<Asteroid>().ChangeScore();
            }
        }
    }
    private void SetEnemy(GameObject asteroid, Vector3 spawnPoint)
    {
        asteroid.SetActive(true);
        asteroid.transform.position = spawnPoint;

    }
}
