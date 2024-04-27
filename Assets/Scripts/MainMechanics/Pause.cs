using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject inGameSettings;

    private ButtonManager _buttonManager;
    
    private bool _isPaused = true;

    private void Start()
    {
        _buttonManager = FindObjectOfType<ButtonManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        _isPaused = !_isPaused;
        if (_isPaused) Time.timeScale = 1;
        if (!_isPaused) Time.timeScale = 0;
        mainMenu.SetActive(!_isPaused);
        inGameSettings.SetActive(_isPaused);
    }

    public void ResumeGame()
    {
        _isPaused = !_isPaused;
        if (_isPaused) Time.timeScale = 1;
        if (!_isPaused) Time.timeScale = 0;
        mainMenu.SetActive(false);
        inGameSettings.SetActive(true);
    }

    public void ExitMenu()
    {
        _isPaused = !_isPaused;
        if (_isPaused) Time.timeScale = 1;
        if (!_isPaused) Time.timeScale = 0;
        mainMenu.SetActive(false);
        _buttonManager.game.SetActive(false);
        _buttonManager.OpenMainMenu();
    }
}
