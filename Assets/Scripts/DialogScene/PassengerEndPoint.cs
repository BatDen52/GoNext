using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerEndPoint : MonoBehaviour
{
    [SerializeField] private DialogPlayer _dialogPlayer;
    [SerializeField] private Passenger _passenger;
    [SerializeField] private bool _canGo;
    [SerializeField] private bool _needParent;

    private float _speed;

    private void OnEnable()
    {
        _speed = 2;
        _dialogPlayer.DialogEnded += LetGo;
    }

    private void OnDisable()
    {
        _dialogPlayer.DialogEnded -= LetGo;
    }

    private void LetGo()
    {
        _canGo = true;
    }

    private void FixedUpdate()
    {
        if (_canGo == true)
        {
            if(!_needParent)
                _passenger.transform.parent=null;

            _passenger.transform.position = Vector3.MoveTowards(_passenger.transform.position, transform.position, Time.deltaTime * _speed);
        }
    }
}

