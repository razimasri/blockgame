using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Transform target;
    private Vector3 move;
    private float speed = 0.1f;
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = transform.parent.GetChild(2); 
    }

    // Update is called once per frame
    void LateUpdate()
    {

        
        move = Vector3.MoveTowards(transform.position, target.position, speed); 
        transform.position = move;


    }
    void Update()
    {
       // if (goal.GetComponent<Goal>().check) { 
        if (transform.childCount == 0)
        {
            
            if (goal.transform.position == transform.position)
            {
                string thisLevel = SceneManager.GetActiveScene().name;
                int intLevel = int.Parse(thisLevel) + 1;
                string nextLevel = intLevel.ToString();
                if (intLevel == 11) nextLevel = "Main Menu";
                Debug.Log(transform.childCount);
                SceneManager.LoadScene(nextLevel);
            }
      //  }
        }
    }

}
