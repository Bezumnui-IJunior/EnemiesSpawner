using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _repeatInterval = 2;

    private WaitForSeconds _intervalDelay;
    private Coroutine _coroutine;

    private void Awake()
    {
        _intervalDelay = new WaitForSeconds(_repeatInterval);
    }

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SpawningTask());
    }

    private void Start()
    {
        if (_spawnPoints.Count == 0)
            throw new Exception("paths cannot be empty");
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator SpawningTask()
    {
        while (enabled)
        {
            int index = Random.Range(0, _spawnPoints.Count);
            _spawnPoints[index].SpawnPathFollower();

            yield return _intervalDelay;
        }
    }
}