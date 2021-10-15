using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 7f;
    [SerializeField] Transform player;
    [SerializeField] Transform target;
    private int layerMask;
    private Vector3 move;


    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {

        // This first part will control where the target moves. Then in fixed update it will raycast   

        if (target.transform.position == player.transform.position)
        {
           
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                move = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
                
            }

           
           

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
  

    private bool CanMove(Vector3 move, Vector3 target)
    {

        Transform[] playerCubes = player.transform.GetComponentsInChildren<Transform>(); //get componenet expensive to call everyloop so it is cached
        foreach (Transform block in playerCubes)  // TODO: swap to a for loop when you can but keeping this readable for now as a beginner
        {
            if (Physics.Raycast(block.position, move, 0.5f, layerMask))
            {
                return false;
            }
        }
        if (!Physics.Raycast(target, Vector3.down))
        {
            return false;
        }

        
        return true;
    }

  private void FixedUpdate() // needed to use fixed update or it sometimes flew by. did the fixed update do this? so i need fixed update to ensure attach but I need late or normale update to not collide with walls...
    {
        target.position += move; //had to move down here or i had the issue of cubes not attach OR wall not detected no longer detecting walls
        

        if (CanMove(move, target.position))
        {
            player.position = Vector3.MoveTowards(player.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            target.transform.position = player.transform.position;
            
        }

        move = Vector3.zero;
    }

}
