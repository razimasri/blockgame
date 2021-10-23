using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;
=======
using UnityEngine.UI;
using System.Collections;
>>>>>>> Stashed changes

public class playerController : MonoBehaviour
{

    private float moveSpeed = 7f;
<<<<<<< Updated upstream
    [SerializeField] Transform player;
    [SerializeField] Transform target;
    private int layerMask;

=======
    [SerializeField] Transform player, target;
    [SerializeField] GameObject menu;
    public LayerMask layerMask;
    private Vector3 move;
    public bool pause;

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.6f);
        pause = false;
        yield return null;
    }
>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        layerMask = LayerMask.GetMask("Wall");
=======
        menu = GameObject.Find("Menu");
        
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream

        // This first part will control where the target moves. Not wall collision added yet. but it is nice and smooth
        Vector3 xinput = Vector3.zero;
        Vector3 zinput = Vector3.zero;
        Vector3 move = Vector3.zero;


        if (target.transform.position == player.transform.position)
=======
        // This first part will control where the target moves. Then in fixed update it will raycast   
        
        if (target.transform.position == player.transform.position && !menu.GetComponent<Toggle>().isOn &&!pause)
>>>>>>> Stashed changes
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

        }

<<<<<<< Updated upstream
=======

    }
>>>>>>> Stashed changes

        if (MoveCheck(move, target.position))
        {
            player.position = Vector3.MoveTowards(player.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            target.transform.position = player.transform.position;
            
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

    private bool MoveCheck(Vector3 move, Vector3 target)
    {

        if (!Physics.Raycast(target, Vector3.down))
        {
            return false;
        }

        foreach (Transform block in player.transform.GetComponentsInChildren<Transform>())
        {
            if (Physics.Raycast(block.position, move, 0.5f, layerMask))
            {
                return false;
            }
        }

        return true;
    }

}
