
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
        music = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        vol = PlayerPrefs.GetInt("vol");
        VolumeSlider(vol);
    }


    public void VolumeSlider(float s_vol)
    {
        vol = (int)s_vol;
        PlayerPrefs.SetInt("vol", vol);
        music.volume = vol / 3f;
        currentSprite.sprite = volumeSprites[vol];

    }



}
