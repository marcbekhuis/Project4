using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject[] Check = new GameObject[1];
    public GameObject[] Ex = new GameObject[1];

    public int controllerMode = 0;
    private bool fullscreen = true;

    private void Start()
    {
        // Get the int from playerpref with name controllerMode
        controllerMode = PlayerPrefs.GetInt("controllerMode");
    }

    // Function to change Fullscreen mode
    public void FullscreenOption()
    {
        // check if you want fullscreen or not
        if (fullscreen == false)
        {
            // sets the resolution and full screen
            Screen.SetResolution(128, 128, true);
            // changes checks
            Ex[0].SetActive(false);
            Check[0].SetActive(true);
            fullscreen = true;
        }
        else if (fullscreen == true)
        {
            // sets the resolution and full screen
            Screen.SetResolution(128, 128, false);
            // changes checks
            Ex[0].SetActive(true);
            Check[0].SetActive(false);
            fullscreen = false;
        }
    }

    // Function to change from keybord and mouse to controller
    public void changeControllerMode()
    {
        // checks which mode you want
        if (controllerMode == 1)
        {
            // changes checks and mode
            Ex[1].SetActive(true);
            Check[1].SetActive(false);
            controllerMode = 0;
        }
        else
        {
            // changes checks and mode
            Ex[1].SetActive(false);
            Check[1].SetActive(true);
            controllerMode = 1;
        }
        // saves the mode you want to play in.
        PlayerPrefs.SetInt("controllerMode", controllerMode);
    }
}
