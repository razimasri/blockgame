using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResetTheLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame

}
