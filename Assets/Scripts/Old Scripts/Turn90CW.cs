using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn90CW : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = new Quaternion(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 - 0.2f * Mathf.Pow(Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup), 2);
        transform.localScale = new Vector3(scale, scale, scale);
        transform.Rotate(Vector3.up, 45 * Time.deltaTime);
    }
}
