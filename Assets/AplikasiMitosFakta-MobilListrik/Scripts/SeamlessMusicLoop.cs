using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessMusicLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.PlayOneShot(musicClip);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicClip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
