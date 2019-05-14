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
        endVolume = audioSource.volume;
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.volume != endVolume)
        {
            audioSource.volume += 1 * Time.deltaTime;
        }
    }
}
