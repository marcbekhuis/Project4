using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject[] Check = new GameObject[1];
    public GameObject[] Ex = new GameObject[1];

    private bool fullscreen = true;

    public void FullscreenOption()
    {
        if (fullscreen == false)
        {
            Screen.SetResolution(128, 128, true);
            Ex[0].SetActive(false);
            Check[0].SetActive(true);
            fullscreen = true;
        }else if (fullscreen == true)
        {
            Screen.SetResolution(128, 128, false);
            Ex[0].SetActive(true);
            Check[0].SetActive(false);
            fullscreen = false;
        }
    }
}
