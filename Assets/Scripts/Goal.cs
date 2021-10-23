using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    [SerializeField] Transform player;

    

    private void OnTriggerStay()
    { 
        if (player.position == transform.position && player.childCount == 0)     // change to a win screen and anybutton to laod next level
        {
            string thisLevel = SceneManager.GetActiveScene().name;
            int intLevel = int.Parse(thisLevel) + 1;
            string nextLevel = intLevel.ToString();
            if (intLevel == 21) nextLevel = "Main Menu";
            SceneManager.LoadScene(nextLevel);
        }
    }
}
