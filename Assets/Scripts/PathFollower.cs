using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private Path _path;
    private IEnumerator<Vector3> _enumerator;
    private bool _isInit;

    private void FixedUpdate()
    {
        Vector3 position = _enumerator.Current!;

        if (transform.position == position)
        {
            if (_enumerator.MoveNext() == false)
                Destroy();

            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, position, _speed);
    }

    public void Init(Path path)
    {
        if (_isInit)
            return;

        _isInit = true;
        _path = path;
        _enumerator = _path.GettingPosition();

        if (_enumerator.MoveNext() == false)
            throw new Exception("Path cannot be empty!");
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}