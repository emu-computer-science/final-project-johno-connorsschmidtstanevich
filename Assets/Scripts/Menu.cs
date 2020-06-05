using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Yeet-Them-All");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsMenu()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Click()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
