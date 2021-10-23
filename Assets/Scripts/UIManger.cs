using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour
{

   [SerializeField] GameObject overlay, loading;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (GameObject.Find("DontDestroyOnLoad"))
        {
            Debug.Log("UI already");
        }
        else DontDestroyOnLoad(this);

        CheckMainMenu();

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckMainMenu();
        if (PlayerPrefs.HasKey("prevScene"))
        {
            if (PlayerPrefs.GetString("prevScene") != SceneManager.GetActiveScene().name) PlayerPrefs.SetString("prevScene", SceneManager.GetActiveScene().name);
        }
        else PlayerPrefs.SetString("prevScene", "FirstLoad");
    }

    void CheckMainMenu()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            overlay.SetActive(false);
            loading.SetActive(false);
            

        }
        else
        {
            overlay.SetActive(true);
            loading.SetActive(true);
        }
    }
}
