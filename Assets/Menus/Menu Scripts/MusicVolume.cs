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

    public void Awake()
    {
        if (GameObject.Find("Music(Clone)") == null)
        {
            Instantiate(BGMusic);
        }
    }
    void Start()
    {
        currentSprite= GetComponent<Image>();
        music = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        

        if (PlayerPrefs.HasKey("vol"))
        {
            Load();
        }
        else
        {
            vol = 3;
        }

        
        
        
    }

    public void Update()
    {
        music.volume = vol / 3f;
        currentSprite.sprite = volumeSprites[vol];
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        vol++;
        if (vol == 4) { vol = 0; }
        
        
        Save();
    }

    private void Load()
    {
        vol = PlayerPrefs.GetInt("vol");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("vol", vol);
    }
}
