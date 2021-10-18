using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;

   
    void Start()
    {
       if (GameObject.Find("DontDestroyOnLoad")) {
            Debug.Log("musicSource already");
        }
       else     DontDestroyOnLoad(this);
        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

}
