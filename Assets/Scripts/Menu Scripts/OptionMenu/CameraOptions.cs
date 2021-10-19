using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOptions : MonoBehaviour
{

    public Toggle[] cameraOption;

    void Start()
    {      
        int cam = PlayerPrefs.GetInt("cam");
        cameraOption[cam].isOn = true;
    }

    public void camToggle(bool camBool)
    {
        int cam = camBool ? 0 : 1;
        PlayerPrefs.SetInt("cam", cam);
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = camBool;
        GameObject.Find("Angle Camera").GetComponent<Camera>().enabled = !camBool;

    }

   

}
