using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsTexture : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        Vector2 scale = new Vector2(GetComponent<Transform>().localScale.x, GetComponent<Transform>().localScale.z);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", scale);
    }

   
}
