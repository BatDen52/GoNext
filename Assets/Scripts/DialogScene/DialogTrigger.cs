using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private DialogPlayer _dialogPlayer;

    public void TriggerDialog()
    {
        _dialogPlayer.StartDialog();
    }
}
