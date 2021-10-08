using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu, levelSelectMenu;
    public GameObject mainFirstButton, levelFirstButton;
    public GameObject music;

    

    public void Update()
    {
 

    }
    public void Main()
    {

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
     
    }


    public void Exit()
    {
        Application.Quit();
    }
}


