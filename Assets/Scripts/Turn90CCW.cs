using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn90CCW : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 - 0.2f * Mathf.Pow(Mathf.Sin(3 * Time.realtimeSinceStartup), 2);
        transform.localScale = new Vector3(scale, scale, scale);
        transform.Rotate(Vector3.up, -45 * Time.deltaTime); 
    }
}
