using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOptions : MonoBehaviour
{

    public Toggle[] cameraOption;
   

    // Start is called before the first frame update
    void Start()
    {      
        int cam = PlayerPrefs.GetInt("cam");
       
        cameraOption[cam].isOn = true;
    }

    public void SaveCam(bool camBool)
    {
       Debug.Log(camBool + " is camBool");
        int cam;
        if (camBool) { cam = 0; }
        else cam = 1;
        PlayerPrefs.SetInt("cam", cam);
    }

    // Update is called once per frame

}
