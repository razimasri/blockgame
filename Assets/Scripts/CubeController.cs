using UnityEngine;



public class CubeController : MonoBehaviour
{
    [SerializeField] Transform player;
    private int layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("Cubes");
        
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other) // current options are to change to tag into cubes
    {
        if (gameObject.CompareTag(other.gameObject.tag))
        {
            gameObject.layer = 10;
            transform.DetachChildren();
            if (gameObject.layer==10 && gameObject.transform.childCount == 0)
            {
                Destroy(gameObject);
            }
        }
       // else if (other.transform.IsChildOf(player) && !transform.IsChildOf(player)) // make the contact cube a child of the player
       // {
       //     transform.parent = other.transform;
        //    AttachCube(gameObject.GetComponent<SphereCollider>());
       // }
        else AttachCube(gameObject.GetComponent<SphereCollider>());
    }

    public void OnTransformParentChanged()
    {
        if (!transform.IsChildOf(player) && gameObject.layer !=10)
        {
            AttachCube(gameObject.GetComponent<SphereCollider>());
        }
    }

    public void AttachCube(Collider connectionCube)
    {
        Collider[] neighbours = Physics.OverlapSphere(connectionCube.transform.position, 0.5f, layerMask);

        for (int i = 0; i < neighbours.Length; i++) // set all other cube to child of contact cube
        {
            if (neighbours[i].transform.IsChildOf(player))//
            {
                connectionCube.transform.parent = neighbours[i].transform;
                //Debug.Log(i + " " + neighbours[i].name + " is now child of " + connetionCube.transform.name);

            }
            else if (!neighbours[i].transform.IsChildOf(player))//
            {
                neighbours[i].transform.parent = connectionCube.transform;
                //Debug.Log(i + " " + neighbours[i].name + " is now child of " + connetionCube.transform.name);
                
            }
        }
        foreach (Transform nested in connectionCube.gameObject.transform)
        {
            AttachCube(nested.gameObject.GetComponent<SphereCollider>());
        }
    }
    public void AlignCubes()
    {
        Vector3Int align = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        transform.position = align;
    }


}
