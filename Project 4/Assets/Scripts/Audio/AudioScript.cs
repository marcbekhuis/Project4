using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;

    float endVolume;

    // Start is called before the first frame update
    void Start()
    {
        //Puts the audio on 0
        endVolume = audioSource.volume;
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Slowly increases the volume until the favored volume is achieved
        if (audioSource.volume < endVolume)
        {
            audioSource.volume += 0.02f * Time.deltaTime;
        }
    }
}
