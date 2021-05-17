using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _aboutPanel;
    [SerializeField] private bool _isMenu;

    private void Awake()
    {
        Time.timeScale = _isMenu? 0: 1;
        _menuPanel.SetActive(_isMenu);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        Time.timeScale = 1;
        _menuPanel.SetActive(false);
    }

    public void About()
    {
        _menuPanel.SetActive(!_menuPanel.activeSelf);
        _aboutPanel.SetActive(!_aboutPanel.activeSelf);
    }
}
