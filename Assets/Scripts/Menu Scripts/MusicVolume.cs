using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Sprite[] volumeSprites;
    private Image currentSprite;
    private AudioSource music;
    private int vol;
    public GameObject BGMusic;


    // Start is called before the first frame update

    void Start()
    {
        if (GameObject.Find("Music(Clone)") == null)
        {
            Instantiate(BGMusic);
            GameObject.Find("Music(Clone)").GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("vol") / 3f;
        }

        currentSprite = GetComponent<Image>();
        music = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        Load();
        Set();

    }

    public void Update()
    {
       

    }

    // Update is called once per frame
    public void VolumeButton()
    {
        vol++;
        if (vol == 4) { vol = 0; }

        Save();
        Set();


    }
    public void VolumeSlider(float s_vol)
    {
        vol = (int)s_vol;
      //  Debug.Log(s_vol + " rounded to " + vol);
        Save();
        Set();


    }

    private void Load()
    {
        vol = PlayerPrefs.GetInt("vol");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("vol", vol);
    }

    public void Set()
    {
       music.volume = vol / 3f;
       currentSprite.sprite = volumeSprites[vol];
    }
}
