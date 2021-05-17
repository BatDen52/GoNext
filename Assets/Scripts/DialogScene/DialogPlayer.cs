using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _dialogPanel;

    private Queue<Dialog> _dialogs;
    private Queue<string> _sentences;
    private string _currentSentence;
    private Coroutine _coroutine;
    Dictionary<string, Color32> _colors;

    public event UnityAction DialogStarting;
    public event UnityAction DialogEnded;

    public void SetDialogs(Queue<Dialog> dialogs, Dictionary<string, Color32> colors)
    {
        _dialogs = dialogs;
        _colors = colors;
    }

    public void StartDialog()
    {
        DialogStarting?.Invoke();
        _dialogPanel.SetActive(true);

        _sentences = new Queue<string>();
        DisplayNextDialog();
    }

    private void DisplayNextDialog()
    {
        if (_dialogs.Count == 0)
        {
            EndDialog();
        }
        else
        {
            Dialog dialog = _dialogs.Dequeue();
            _name.text = dialog.Name;
            _name.color = _text.color = _colors[dialog.Name];

            _sentences.Clear();

            foreach (string sentence in dialog.Sentencens)
                _sentences.Enqueue(sentence);

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0 && _coroutine == null)
        {
            DisplayNextDialog();
        }
        else
        if (_coroutine == null)
        {
            _currentSentence = _sentences.Dequeue();
            _coroutine = StartCoroutine(TypeSentence(_currentSentence));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _text.text = _currentSentence;
        }
    }

    private IEnumerator TypeSentence(string sentence)
    {
        _text.text = "";

        foreach (var letter in sentence.ToCharArray())
        {
            _text.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        _coroutine = null;
    }

    public void EndDialog()
    {
        _dialogPanel.SetActive(false);
        DialogEnded?.Invoke();
    }
}