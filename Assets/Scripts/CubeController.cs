using System.Collections;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    private Transform player;
    private int cb;
    [SerializeField] LayerMask layerMask, playerLayer;
    [SerializeField] Collider ownCollider;
    private Renderer m_Renderer;

    void Start()
    {
       
        player = GameObject.Find("Player").transform;

        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.EnableKeyword("_NORMALMAP");
    }

    private void Update()
    {
        //TODO: right now its check and update the texture every frame need to swap to an event
        //i need this to only occur on a toggle but so many object have it.
        if (cb != PlayerPrefs.GetInt("cb"))
        {
            cb = PlayerPrefs.GetInt("cb");
            m_Renderer.material.SetFloat("_BumpScale", cb);
        }
    }


    private void OnTriggerEnter(Collider other) // current options are to change to tag into cubes
    {
        player = GameObject.Find("Player").transform; // even thought his is assigned at start i for some reason forgets? ah, what a pain
        if (gameObject.CompareTag(other.gameObject.tag)) // TODO: not happy with this having to swap to a layer and check child count.
                                                         // detach children should be preventing all this extra destruction.
                                                         // maybe I could make a destroy empty object that itterated through it.
        {
            gameObject.layer = 10;
            transform.DetachChildren();
            transform.parent = null;
            if (gameObject.layer == 10 && gameObject.transform.childCount == 0) StartCoroutine(Fade(Vector3.up));

        }
        else if (other.transform.IsChildOf(player) && !transform.IsChildOf(player)) // make the contact cube a child of the player
        {
            transform.parent = other.transform;

            AttachCube(ownCollider);
        }

    }


    public void AttachCube(Collider connectionCube) // keeps the heirachy in a logical order.  
    {
        
        
        Collider[] neighbours = Physics.OverlapSphere(connectionCube.transform.position, 0.5f, layerMask);

        int count = neighbours.Length; //faster to cache length
        for (int i = 0; i < count; i++) // set all other cube to child of contact cube
        {

            if (Physics.CheckSphere(neighbours[i].transform.position, 0.5f, playerLayer))
            {

                neighbours[i].transform.parent = player;
            }
            if (neighbours[i].transform.IsChildOf(player))
            {
                connectionCube.transform.parent = neighbours[i].transform;

            }
            else if (!neighbours[i].transform.IsChildOf(player))
            {
                neighbours[i].transform.parent = connectionCube.transform;

            }
        }
        foreach (Transform nested in connectionCube.gameObject.transform) // TODO: swap to a for loop when you can but keeping this readable for now as a beginner
        {
            AttachCube(nested.gameObject.GetComponent<SphereCollider>());
           
        }

        //AlignCube();

    }
    public void OnTransformParentChanged()  // Sometime while detaching a cube wil no longer be connected to the player since it parent was detroyed so we need to do a nother neightbout check 
    {                                       // dont like it but see if i can eliminate
        if (transform.parent == null && gameObject.layer != 10)

        {
            if (AllFall())
            {
                StartCoroutine(Fade(Vector3.down));
            }
            
            else{                AttachCube(ownCollider);
            }
        }
        float normal = transform.IsChildOf(player) ? 1 : 0;
        m_Renderer.material.SetFloat("_DetailNormalMapScale", normal);
    }
    public bool AllFall()
    {
        Transform[] fallList = GetComponentsInChildren<Transform>();
        foreach (Transform block in fallList)  //it is only doing first level children
        {
            if (Physics.Raycast(block.position, Vector3.down))
            {
                return false;
            }
        }
        return true;
    }

    public IEnumerator Fade(Vector3 direction)
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)  // fade an object and also moves it up or down based on fade direction
        {

            Color fadeColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = fadeColor.a - (1f * Time.deltaTime);

            fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
            m_Renderer.material.color = fadeColor;
            transform.Translate(direction * Time.deltaTime * 5);

            yield return null;
        }
        Destroy(gameObject);
    }

    private void AlignCube()
    {
        Vector3Int align = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        transform.position = align;
    }
}
