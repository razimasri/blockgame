using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindOption : MonoBehaviour
{
    [SerializeField] Toggle cbMode;
    
    // Start is called before the first frame update
    void Start()
    {
        int cb = PlayerPrefs.GetInt("cb");
        cbMode.isOn = (cb == 1) ? true : false; 
    }

    // Update is called once per frame
   public void cbToggle(bool cbBool)
    {
        int cb = cbBool ? 1 : 0;
        PlayerPrefs.SetInt("cb", cb);
       
    }
}
