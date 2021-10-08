using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn180 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = 1 -  0.2f*Mathf.Pow(Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup),2);
        transform.localScale = new Vector3(scale, scale, scale);
        transform.localRotation = Quaternion.AngleAxis(Mathf.Cos(Mathf.PI * Time.realtimeSinceStartup) * 90,Vector3.up );
    }
}
