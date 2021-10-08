using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetMove : MonoBehaviour
{
    
   
    public bool wall;
    public Transform player;
    public Vector3 origin;
    public Vector3 move;
    public Vector3 publicMove;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;

        //place in late update to make sure player has time to move to int before next input

        if (Input.GetKeyDown(KeyCode.R)) {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("Main Menu");

        }

        if (transform.position == player.position)
        {
            int xInput = 0;
            int zInput = 0;
            if (Input.GetButtonDown("Horizontal"))
            {
                xInput = (int)Input.GetAxisRaw("Horizontal");
            }
            else if (Input.GetButtonDown("Vertical"))
            {
                zInput = (int)Input.GetAxisRaw("Vertical");
            }

            origin = transform.position;
            move = new Vector3Int(xInput, 0, zInput);
            
  



        }


    }

    private void LateUpdate()
    {
        transform.Translate(move);
       

        if (!Physics.Raycast(transform.position, Vector3.down) || wall)
        {
            transform.position = origin;
            wall = false;
        }
        

    }
}
