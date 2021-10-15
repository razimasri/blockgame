using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    [SerializeField] Transform player;

    void Update()
    {
        float scale = 1 - 0.2f * Mathf.Pow(Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup), 2);
        transform.localScale = new Vector3(scale, scale, scale); 
    }

    private void OnTriggerStay()
    { 
        if (player.position == transform.position && player.childCount == 0)     // change to a win screen and anybutton to laod next level
        {
            string thisLevel = SceneManager.GetActiveScene().name;
            int intLevel = int.Parse(thisLevel) + 1;
            string nextLevel = intLevel.ToString();
            if (intLevel == 11) nextLevel = "Main Menu";
            SceneManager.LoadScene(nextLevel);
        }
    }
}
