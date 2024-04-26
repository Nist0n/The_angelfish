using System.Collections;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject inGameMenu;

    public void OpenMainMenu()
    {
        settingsMenu.SetActive(false);
        inGameMenu.SetActive(false);
        mainMenu.SetActive(true);
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
}
