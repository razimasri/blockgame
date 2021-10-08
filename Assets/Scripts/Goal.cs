using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{
    public GameObject playerEmpty;
    private Transform player;
    public bool check;
    public int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Cubes");
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 - 0.2f * Mathf.Pow(Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup), 2);
        transform.localScale = new Vector3(scale, scale, scale);

        if (Physics.Raycast(transform.position, Vector3.forward, 1, layerMask)) { check = false; }
        else if (Physics.Raycast(transform.position, Vector3.back, 1, layerMask)) { check = false; }

        else if (Physics.Raycast(transform.position, Vector3.left, 1, layerMask)) { check = false; }

        else if (Physics.Raycast(transform.position, Vector3.right, 1, layerMask)) { check = false; }
        else check = true;


    }

    
   
}
