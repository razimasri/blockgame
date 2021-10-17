using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderAwake : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        int vol = PlayerPrefs.GetInt("vol");
        GetComponent<Slider>().value = vol;
    }


}
