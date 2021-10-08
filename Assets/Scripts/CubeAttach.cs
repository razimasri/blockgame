using System.Collections;
using UnityEngine;

public class CubeAttach : MonoBehaviour
{

    //this is my first attempt at coding complext set of behaviours so it have many bad spaghetti aspects
    //wont fix until i get a good demo

    public bool maybeFall, once;
    public int fadeDirection;
    public GameObject playerEmpty;
    private Transform player;
    private Transform target;
    public Texture normal;
    public Renderer m_Renderer;


    public IEnumerator Fade()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)  // fade an object and also moves it up or down based on fade direction
        {
            m_Renderer.material.SetTexture("_BumpMap", normal);
            m_Renderer.material.SetTextureScale("_MainTex", new Vector2(3, 3));
            Color fadeColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = fadeColor.a - (0.5f * Time.deltaTime);

            fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
            m_Renderer.material.color = fadeColor;
            transform.Translate(Vector3.up * Time.deltaTime * 5 * fadeDirection);
            once = true;

            if (this.GetComponent<Renderer>().material.color.a < 0) // detroys an object once it has faded out. othersie a shadow remains

            {
                Destroy(gameObject);
            }

            yield return null;
        }

    }


    public bool AllFall()
    {
        // Iterates through all direct childs of this object

        foreach (Transform child in transform)
        {
            if (!child.gameObject.GetComponent<CubeAttach>().maybeFall) return false; //check to see if bool maybefall is true
        }

        return true;
    }


    // Start is called before the first frame update
    void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.EnableKeyword("_NORMALMAP");

        playerEmpty = GameObject.Find("PlayerEmpty");
        player = playerEmpty.transform.GetChild(0);
        target = playerEmpty.transform.GetChild(1);

        if (PlayerPrefs.HasKey("ColourBlind"))
        {
            int cb = PlayerPrefs.GetInt("ColourBlind");
            m_Renderer.material.SetFloat("_Detail", cb);
        }


    }


    // Update is called once per frame
    void Update()
    {


        if (transform.parent != null)
        {

            if (transform.IsChildOf(player))
            {
                m_Renderer.material.SetTexture("_BumpMap", normal);
            }
            else { m_Renderer.material.SetTexture("_BumpMap", null); }
        }

        //make sure object are always same alpha as parent


        if (!transform.IsChildOf(player))  //maybee fall setter. No object attached to player will fall
        {
            if (transform.parent != null)
            {
                Color change = this.m_Renderer.material.color;
                float alpha = transform.parent.GetComponentInParent<Renderer>().material.color.a;
                change.a = alpha;
                this.m_Renderer.material.color = change;

            }

            if (Physics.Raycast(transform.position, Vector3.down, 6) || !AllFall()) //checks to see if cube is above floor or any direct children
            {
                maybeFall = false;
            }
            else maybeFall = true;
        }
        if (transform.parent == null && maybeFall) //only the parent of a cube group will check to fall
        {

            if (AllFall() && !once)

            {
                //once = true;
                fadeDirection = -1;
                StartCoroutine(Fade());


            }


        }




    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.parent != null)
        {
            if (other.transform.IsChildOf(player) && fadeDirection == 0) //will only attach to mainplayer and nonfading cubes
            {
                gameObject.transform.parent = other.gameObject.transform;

            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //The current way to check if 2 cubes should destroy each other but is done by component and i assume i should make tags
        string objectColor = m_Renderer.material.ToString();
        string otherColor = other.GetComponent<Renderer>().material.ToString();


        if (!once && objectColor == otherColor) // if two colour hit. isolates cubes and makes it float up and fade
        {


            transform.DetachChildren();
            transform.parent = null;
            fadeDirection = 1;
            StartCoroutine(Fade());


        }


    }

    void LateUpdate() // make sure the cubes are alwqays on an int
    {

        if (player.transform.position == target.transform.position && m_Renderer.material.color.a == 1)
        {
            Vector3Int align = new Vector3Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
            transform.position = align;
        }



    }
}

