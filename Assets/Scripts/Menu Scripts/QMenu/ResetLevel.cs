using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    
    public void ResetTheLevel()
    {
        string name = SceneManager.GetActiveScene().name;
              
        SceneManager.LoadScene(name);

    }

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) ResetTheLevel();
    }



}