using UnityEngine;
using UnityEngine.UI;


public class CameraSelect : MonoBehaviour
{
    public Sprite[] cameraSprites;
    private Image currentSprite;
    public Camera[] cameras;
    private int cam, old;


    // Start is called before the first frame update
    void Start()
    {
        cameras = new Camera[2];
        cameras[0] = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameras[1] = GameObject.Find("Angle Camera").GetComponent<Camera>();
        currentSprite = GetComponent<Image>();    

       if (PlayerPrefs.HasKey("cam"))
        {
            Load();
            Debug.Log("Loading cam = " + cam);
        }
        else
        {
            cam = 0;
            Debug.Log("No cam so I will set it " + cam);
        }
        Set();
    }

    // Update is called once per frame
    void Update()
    {
     //   if (Input.GetKeyDown(KeyCode.C))
     //   {
     //       ChangeCamera();
      //  }
    }
    public void ChangeCamera()
    {
        cameras[cam].enabled = false;
        old = cam;
        cam++;
        if (cam == cameras.Length) cam = 0;
        Save();
        Set();
    }


    private void Load()
    {
        cam = PlayerPrefs.GetInt("cam");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("cam", cam);
        Debug.Log("save cam = " + cam);
    }

    public void Set()
    {
        cameras[old].enabled = false;
        cameras[cam].enabled = true;
        currentSprite.sprite = cameraSprites[cam];
    }

}
