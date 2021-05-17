using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharonStateSwitcher : MonoBehaviour
{
    [SerializeField] private DialogPlayer _dialogPlayer;
    [SerializeField] private Animator _charon;
    [SerializeField] private bool _isSwim;

    private void OnEnable()
    {
        if (_isSwim)
            Swim();
        else
            Stop();

        _dialogPlayer.DialogStarting += Stop;   
        _dialogPlayer.DialogEnded += Swim;   
    }

    private void OnDisable()
    {
        _dialogPlayer.DialogStarting -= Stop;
        _dialogPlayer.DialogEnded -= Swim;
    }

    private void Swim()
    {
        _charon.ResetTrigger("Stoped");
        _charon.SetTrigger("Going");   
    }

    private void Stop()
    {
        _charon.ResetTrigger("Going");
        _charon.SetTrigger("Stoped");
    }
}
