using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneScript : MonoBehaviour
{
    public GameObject skipText;

    float timer;

    //Plays a video at start
    void Start()
    {
        // Gets the renderer component from the object this script is on and plays the video.
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        // disables skip text
        skipText.SetActive(false);
    }

    private void Update()
    {
        // adds time for timer
        timer += 1 * Time.deltaTime;
        // checks if you pressed P or the time has passed.
        if (timer >= 27.25f || Input.GetKeyDown(KeyCode.P))
        {
            // changes scene to game.
            SceneManager.LoadScene(1);
        }
        // check if 3 sec of the intro have passed.
        else if (timer >= 3)
        {
            // activates skip text
            skipText.SetActive(true);
        }
    }
}