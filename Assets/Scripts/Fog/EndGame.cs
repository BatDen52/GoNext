using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private DialogPlayer _dialogPlayer;
    [SerializeField] private Animator _darkPanel;

    private void OnEnable()
    {
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
        yield return new WaitForSeconds(2);
        _darkPanel.gameObject.SetActive(true);
        _darkPanel.Play("HideScene");
    }
}
