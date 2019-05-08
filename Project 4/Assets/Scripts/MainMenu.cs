using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int nextScene = 1;
    private int open = 0;
    public GameObject optionsMenu;

    private void Start()
    {
        Screen.SetResolution(128, 128, true);
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
        if (open == 0)
        {
            open++;
            optionsMenu.gameObject.SetActive(true);
        }
        else if (open == 1)
        {
            open--;
            optionsMenu.gameObject.SetActive(false);
        }
    }
}
