using System;
using UnityEngine;

[RequireComponent(typeof(Path))]
public class SpawnPoint : MonoBehaviour
{ 
    [SerializeField] private PathFollower _pathFollowerPrefab;

    private Path _path;

    private void Awake()
    {
        _path = GetComponent<Path>();
    }

    public void SpawnPathFollower()
    {
        PathFollower pathFollower = Instantiate(_pathFollowerPrefab);
        pathFollower.Init(_path);
       
        pathFollower.transform.position = transform.position;
    }
    
}