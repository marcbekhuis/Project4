using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int nextScene = 4;
    private int open = 0;
    public GameObject optionsMenu;

    private void Start()
    {
        //sets the screen resolution to 128x128 and makes it fullscreen
        Screen.SetResolution(128, 128, true);
    }

    public void StartGamer()
    {
        //Shifts to the next scene in numerical order
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        //Ends application
        Application.Quit();
    }

    public void OptionsMenu()
    {
        if (open == 0)
        {
            //opens the options menu
            open++;
            optionsMenu.gameObject.SetActive(true);
        }
        else if (open == 1)
        {
            //closes the options menu
            open--;
            optionsMenu.gameObject.SetActive(false);
        }
    }
}
