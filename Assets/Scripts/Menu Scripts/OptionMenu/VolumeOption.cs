
using UnityEngine;
using UnityEngine.UI;

public class VolumeOption : MonoBehaviour
{
    public Sprite[] volumeSprites;
    private Image currentSprite;
    private AudioSource music;
    private int vol;

    void Start()
    {
        currentSprite = GetComponent<Image>();
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>(); //change to tag at some point
        vol = PlayerPrefs.GetInt("vol");
     
    }


    public void VolumeSlider(float s_vol)
    {
        vol = (int)s_vol;
        PlayerPrefs.SetInt("vol", vol);
        
        music.volume = vol / 3f;
       currentSprite.sprite = volumeSprites[vol]; //hmm causes a bug on load. figure out later. not critical

    }



}
