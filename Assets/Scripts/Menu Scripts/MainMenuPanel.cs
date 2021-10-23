using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    private string[] prefNames = { "vol", "cam", "cb", "music", "sfx", "lvl" }; // all the player pref names
    private int[] prefs = { 3, 0, 0, 1, 1, 0 };  // my defualts will only load it there are none
    [SerializeField] GameObject[] cameraOptions, volumeOptions, musicOptions, soundEffectsOptions, colorBlindOptions; 
    [SerializeField] Sprite[] cameraSprites, volumeSprites;

    

   
    private void SetSoundEffects()
    {
        
    }

    private void SetColourBlind()
    {
        
    }



public void Exit()
{
    Application.Quit();
}
}
