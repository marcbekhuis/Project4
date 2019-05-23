using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip deathNoise;
    public AudioClip deathMusic;

    public GameObject deathUI;

    float endVolume;
    bool playedOnce;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Turns off the Overlay
        deathUI.SetActive(false);
        //Plays the sound of dying
        audioSource.clip = deathNoise;
        audioSource.volume = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        //Slowly turn on music after the death sound has played
        if (playedOnce == true)
        {
            if (audioSource.volume < endVolume)
            {
                audioSource.volume += 0.02f * Time.deltaTime;
            }
        }

        //Checks if the death sound has played once
        timer += 1 * Time.deltaTime;
        if (timer >= 5.6f)
        {
            if (playedOnce == false)
            {
                if (timer >= 8)
                {
                    //Changes the song thats playing to the death song
                    playedOnce = true;

                    endVolume = audioSource.volume;
                    audioSource.volume = 0;

                    audioSource.clip = deathMusic;
                    audioSource.Play();
                }
                else
                {
                    //Stops the audio from playing
                    audioSource.Stop();
                    deathUI.SetActive(true);
                }
            }
        }
    }
}
