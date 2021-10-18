using UnityEngine;
using UnityEngine.UI;


public class CameraSelect : MonoBehaviour
{
    public Sprite[] cameraSprites;
    private Image currentSprite;
    public Camera[] cameras;
    private int cam;
    public Toggle toggle;
    // TODO I think this is redundents but fix other code first. been on menu for 3 days

 void Start()
    {
        toggle.isOn = PlayerPrefs.GetInt("cam") == 0 ? true : false;
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.C))
        {
            toggle.isOn = toggle.isOn ? false : true;
            cameraToggle(toggle.isOn);
           
        }
      
    }


    public void cameraToggle(bool camBool)
    {
       
        cam = camBool ? 0 : 1;
        
        Image image = GetComponent<Image>();
            image.sprite = cameraSprites[cam];
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = camBool;
        GameObject.Find("Angle Camera").GetComponent<Camera>().enabled = !camBool;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("cam", cam);
      
    }

   


}
