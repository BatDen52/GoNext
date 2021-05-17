using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    [SerializeField] private DialogTrigger _trigger;
    [SerializeField] private DialogPlayer _dialogPlayer;
    [SerializeField] private GameObject _endPoint;

    private void OnEnable()
    {
        StartCoroutine(TriggerDialog());
        _dialogPlayer.DialogEnded += GoAway;
    }

    private void OnDisable()
    {
        _dialogPlayer.DialogEnded -= GoAway;
    }

    private void GoAway()
    {
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
        yield return new WaitForSeconds(3);
        _endPoint.transform.parent = null;
        _endPoint.SetActive(true);
    }

    private IEnumerator TriggerDialog()
    {
        yield return new WaitForSeconds(3);
        _trigger.TriggerDialog();
    }
}
