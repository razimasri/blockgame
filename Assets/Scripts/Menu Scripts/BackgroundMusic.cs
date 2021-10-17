using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;

    // Start is called before the first frame update
    void Start()
    {
       if (GameObject.Find("DontDestroyOnLoad")) {
            Debug.Log("musicSource already");
        }
       else     DontDestroyOnLoad(this);
        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

    // Update is called once per frame
    void Update()
    {
        //some other junk to follow around the don't destroy on load

        
  
        
    }
}
