using UnityEngine.SceneManagement;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("lvl")== 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lvl"));
    }
}
