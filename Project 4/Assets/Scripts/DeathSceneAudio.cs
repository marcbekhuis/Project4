using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip deathNoise;
    public AudioClip deathMusic;

    float endVolume;
    bool playedOnce;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = deathNoise;
        audioSource.volume = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playedOnce == true)
        {
            if (audioSource.volume < endVolume)
            {
                audioSource.volume += 0.02f * Time.deltaTime;
            }
        }

        timer += 1 * Time.deltaTime;
        if (timer >= 6)
        {
            playedOnce = true;

            endVolume = audioSource.volume;
            audioSource.volume = 0;

            audioSource.clip = deathMusic;
        }
    }
}
