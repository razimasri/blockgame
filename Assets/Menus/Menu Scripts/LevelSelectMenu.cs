using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    // Start is called before the first frame update


    public void LevelSelect(string level)
    {
        
        SceneManager.LoadScene(level);
    }
}
