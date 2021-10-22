using UnityEngine;

public class PrefsManager : MonoBehaviour
{


    //Loads all player prefs or sets to defaults. Seem smostly redundent right now
    private string[] prefNames = { "vol", "cam", "cb", "music", "sfx", "lvl" }; // all the player pref names
    private int[] prefs = { 3, 0, 0, 1, 1, 0 };  // my defualts will only load it there are none  
    [SerializeField] GameObject BGMusic, PlayUI;

    private void Awake()
    {
        LoadPrefs();
        LoadMusic();
        LoadCamera();
        LoadUI();
    }



    public void LoadPrefs()
    {
        int length = prefNames.Length;
        for (int i = 0; i < length ; i++)
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

        cameras[0].enabled = prefs[1] == 0 ? true : false; // need to learn how to use switch statements
        cameras[1].enabled = prefs[1] == 1 ? true : false;
    }

    private void LoadMusic() //maybe fold into UI
    {
        if (GameObject.FindGameObjectWithTag("Music") == null)
        {
            Instantiate(BGMusic);
        }

    }
    
    private void LoadUI()
    {
        if (GameObject.FindGameObjectWithTag("PlayUI") == null) Instantiate(PlayUI);
    }
}
