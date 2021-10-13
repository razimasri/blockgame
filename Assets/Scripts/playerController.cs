using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public float moveSpeed = 7f;
    [SerializeField] Transform player;
    [SerializeField] Transform target;

    private int layerMask;



    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {

        // This first part will control where the target moves. Not wall collision added yet. but it is nice and smooth
        Vector3 xinput = Vector3.zero;
        Vector3 zinput = Vector3.zero;
        Vector3 move = Vector3.zero;


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

        }


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
