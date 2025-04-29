using System;
using UnityEngine;

class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 100;

    private Vector3 _direction;
    private bool _isInit;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }

    public void Init(Vector3 direction)
    {
        if (_isInit)
            return;

        _isInit = true;
        _direction = direction;
    }
}