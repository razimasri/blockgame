using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Sprite[] volumeSprites;
    private Image currentSprite;
    private AudioSource music;
    private int vol;
  
    void Start()
    {
        currentSprite = GetComponent<Image>();
        music = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        vol = PlayerPrefs.GetInt("vol");
        currentSprite.sprite = volumeSprites[vol];
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) VolumeButton();
    }

    public void VolumeButton()
    {
        vol++;
        if (vol == 4) { vol = 0; }

        PlayerPrefs.SetInt("vol", vol);
        music.volume = vol / 3f;
        currentSprite.sprite = volumeSprites[vol];

    }


}
