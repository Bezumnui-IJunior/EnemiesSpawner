using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private float _repeatInterval = 2;

    private WaitForSeconds _intervalDelay;
    private Coroutine _coroutine;

    private void Awake()
    {
        _intervalDelay = new WaitForSeconds(_repeatInterval);
    }

    private void Start()
    {
        if (_spawnPoints.Count == 0)
            throw new Exception("spawnPoints cannot be empty");

        StartSpawn();
    }

    [ContextMenu("Start spawning")]
    private void StartSpawn()
    {
        StopSpawn();
        _coroutine = StartCoroutine(SpawningTask());
    }

    [ContextMenu("Stop spawning")]
    private void StopSpawn()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator SpawningTask()
    {
        while (enabled)
        {
            yield return _intervalDelay;

            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.Init(RandomizeDirection());

            int index = Random.Range(0, _spawnPoints.Count);
            enemy.transform.position = _spawnPoints[index].transform.position;
        }
    }

    private Vector3 RandomizeDirection()
    {
        return new Vector3(RandomizePoint(), 0, RandomizePoint());
    }

    private float RandomizePoint() => Random.Range(-1f, 1f);
}