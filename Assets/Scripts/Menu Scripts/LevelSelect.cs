
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
   
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);

    }
}
