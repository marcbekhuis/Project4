using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int nextScene = 1;

    private void Start()
    {
        Screen.SetResolution(128, 128, false);
    }

    public void StartGamer()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(1);
    }
}
