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
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        skipText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            timer += 27;
        }

        timer += 1 * Time.deltaTime;
        if (timer >= 27.25f)
        {
            SceneManager.LoadScene(1);
        }else if (timer >= 3)
        {
            skipText.SetActive(true);
        }
    }
}