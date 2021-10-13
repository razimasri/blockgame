using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public bool cannotMove;
    public float moveSpeed = 7f;
    public Vector3 move;
    [SerializeField] Transform player;
    [SerializeField] Transform target;
    private Vector3Int origin;


    //rebuild player movemtn script. no wall or ovehangecollisions detection fully implementeed yet


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // This first part will control where the target moves. Not wall collision added yet. but it is nice and smooth
        Vector3 xinput = Vector3.zero;
        Vector3 zinput = Vector3.zero;
        origin = new Vector3Int(Mathf.RoundToInt(player.transform.position.x), 0, Mathf.RoundToInt(player.transform.position.z));

        if (target.transform.position == player.transform.position)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                xinput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                zinput = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
                //target.position += zinput;
            }


            move = xinput + zinput;
            target.position += move;
            if (!Physics.Raycast(target.position, Vector3.down))
            {
                cannotMove = true;

            }


        }


        foreach (Transform g in player.transform.GetComponentsInChildren<Transform>())
        {
            Debug.Log(g.name);
        }

        if (cannotMove)
        {
            target.transform.position = origin;
            player.transform.position = origin;
            cannotMove = false;
        }
        else
        {

            player.position = Vector3.MoveTowards(player.position, target.position, moveSpeed * Time.deltaTime);
        }

        //Menu commands - also will add music commands but focus on walls

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }

        

         
               


    }
}
