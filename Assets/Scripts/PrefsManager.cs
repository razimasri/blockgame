using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsManager : MonoBehaviour
{
    // Start is called before the first frame update
    
 //Loads all player prefs or sets to defaults. Seem smostly redundent right now
    private string[] prefNames = { "vol", "cam", "cb", "music", "sfx", "lvl" }; // all the player pref names
    private int[] prefs = { 3, 0, 0, 1, 1, 0 };  // my defualts will only load it there are none  
    public GameObject BGMusic;
    private void Awake()
    {
        LoadPrefs();
        LoadMusic();
        LoadCamera();

    }



    public void LoadPrefs()
    {
        for (int i = 0; i < prefNames.Length; i++)
        {

            if (PlayerPrefs.HasKey(prefNames[i]))
            {
                prefs[i] = PlayerPrefs.GetInt(prefNames[i]);
            }
            else
            {
                                PlayerPrefs.SetInt(prefNames[i], prefs[i]);
            }

        }
    }


    public void LoadCamera()
    {
        
         Camera[] cameras = new Camera[2];
         cameras[0] = GameObject.Find("Main Camera").GetComponent<Camera>();
         cameras[1] = GameObject.Find("Angle Camera").GetComponent<Camera>();

         if (prefs[1] ==0)
         {
            Debug.Log("got this far");
             cameras[0].enabled = true;
            cameras[1].enabled = false;
         }
         else if (prefs[1] == 1)
         {
             cameras[1].enabled = true;
            cameras[0].enabled = false;
        }
    }


    private void LoadMusic()
    {
        if (GameObject.Find("Music(Clone)") == null)
        {
            Instantiate(BGMusic);
            GameObject.Find("Music(Clone)").GetComponent<AudioSource>().volume = prefs[0] / 3f;
        }
    }

}
