using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _afterDialogSpeed;
    [SerializeField] private float _postDialogSpeed;

    private float _currentSpeed;

    private void OnEnable()
    {
        _currentSpeed = _afterDialogSpeed;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _currentSpeed);
    }

    public void Go()
    {
        _currentSpeed = _postDialogSpeed;
    }

    public void Stop()
    {
        _currentSpeed = 0;
    }
}
