using System;
using System.Collections;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject inGameMenu;
    [SerializeField] private GameObject backButtonMenu;
    [SerializeField] private GameObject backButton;
    public GameObject game;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject backGround;

    public void OpenMainMenu()
    {
        backButtonMenu.SetActive(true);
        settingsMenu.SetActive(false);
        inGameMenu.SetActive(false);
        mainMenu.SetActive(true);
        backGround.SetActive(true);
    }

    public void CloseMainMenu()
    {
        StartCoroutine(CloseMainMenuCoroutine());
    }
    public IEnumerator CloseMainMenuCoroutine()
    {
        yield return new WaitForSeconds(1);
        inGameMenu.SetActive(true);
        mainMenu.SetActive(false);
        game.SetActive(true);
    }

    public void OpenSettingsMenu()
    {
        StartCoroutine(OpenSettingsMenuCoroutine());
    }
    public IEnumerator OpenSettingsMenuCoroutine()
    {
        yield return new WaitForSeconds(1);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        backButtonMenu.SetActive(true);
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }
    public IEnumerator QuitGameCoroutine()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public void ActivateInGameSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        backButton.SetActive(true);
    }
    
    public void DeactivateInGameSettings()
    {
        backButton.SetActive(false);
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
