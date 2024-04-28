using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject inGameMenu;
    [SerializeField] private GameObject backButtonMenu;
    [SerializeField] private GameObject backButton;
    public GameObject game;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject looseMenu;
    [SerializeField] private GameObject backGround;
    [SerializeField] private Image image;

    public void OpenMainMenu()
    {
        backButtonMenu.SetActive(true);
        settingsMenu.SetActive(false);
        inGameMenu.SetActive(false);
        looseMenu.SetActive(false);
        mainMenu.SetActive(true);
        backGround.SetActive(true);
    }

    public void CloseMainMenu()
    {
        if (PlayerPrefs.GetInt("isFirstSession") == 0)
        {
            StartCoroutine(CloseMainMenuCoroutine());
            image.gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(CloseMainMenuCoroutine());
            AudioManager.instance.PlayMusic("inGameMusic");
        }
    }
    public IEnumerator CloseMainMenuCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        inGameMenu.SetActive(true);
        mainMenu.SetActive(false);
        game.SetActive(true);
        PlayerPrefs.SetInt("isFirstSession", 1);
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
        backGround.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        backButton.SetActive(true);
    }
    
    public void DeactivateInGameSettings()
    {
        backGround.SetActive(false);
        backButton.SetActive(false);
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
