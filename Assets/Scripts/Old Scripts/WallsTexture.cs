
using UnityEngine;

public class WallsTexture : MonoBehaviour
{
     void Start()
    {
        Vector2 scale = new Vector2(GetComponent<Transform>().localScale.x, GetComponent<Transform>().localScale.z);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", scale);
    }
}
