using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position-_target.position;
    }

    private void Update()
    {
        transform.position = _offset+_target.position;
    }
}
