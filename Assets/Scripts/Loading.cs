using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] TMP_Text _levelText, _levelCaption, _cornerLevelText;
    private int level;
    
    private string[] caption;

    // Start is called before the first frame update

    void Awake()
    {
        CaptionText();
        //Debug.Log("hey captions are being loaded again");
    }


    void OnEnable()
    {


        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            level = int.Parse(SceneManager.GetActiveScene().name);
            if (level > PlayerPrefs.GetInt("lvl")) PlayerPrefs.SetInt("lvl", level);

            string levelString = ("LEVEL " + level + "/20");

            _levelText.text = levelString;
            _cornerLevelText.text = levelString;
            _levelCaption.text = caption[level];

        }


        if (PlayerPrefs.GetString("prevScene") == SceneManager.GetActiveScene().name)
        {
            Disable();
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) Disable();
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    void CaptionText()   // TODO: at some point learn how to put this all into and external txt or csv file. also need for localisation but this will work for now
    {
        caption = new string[40];

        caption[0] = "A game about isolation";
        caption[1] = "Get out there";
        caption[2] = "You can't move on if you are still atached";
        caption[3] = "Matches disappear";
        caption[4] = "Reach out";
        caption[5] = "Explore another side of yourself";
        caption[6] = " ";
        caption[7] = " ";
        caption[8] = " ";
        caption[9] = " ";
        caption[10] = " ";
        caption[11] = " ";
        caption[12] = " ";
        caption[13] = " ";
        caption[14] = " ";
        caption[15] = " ";
        caption[16] = " ";
        caption[17] = " ";
        caption[18] = " ";
        caption[19] = " ";
        caption[20] = " ";
        caption[21] = " ";



    }

}
