using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpenClose : MonoBehaviour
{
    [SerializeField] private Mover _player;
    [SerializeField] private Animator _darkPanel;
    [SerializeField] private string _nextSceneTitle;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _clip;

    [SerializeField] private bool _isMenu;
    [SerializeField] private bool _needAudio;

    private void Awake()
    {
        if (!_isMenu) _darkPanel.Play("ShowScene");
        StartCoroutine(PanelDeactivator());
    }

    private IEnumerator PanelDeactivator()
    {
        yield return new WaitForSeconds(2);
        _darkPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Boat>(out Boat boat))
        {
            _darkPanel.gameObject.SetActive(true);
            _darkPanel.Play("HideScene");
            StartCoroutine(NextScene());
        }
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);

        if (_needAudio)
        {
            _audio.clip = _clip;
            _audio.Play();
            yield return new WaitForSeconds(2);
        }

        if (_nextSceneTitle != string.Empty && _nextSceneTitle != null)
            SceneManager.LoadScene(_nextSceneTitle);
    }
}
