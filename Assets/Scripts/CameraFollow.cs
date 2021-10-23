
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player, Vector3.forward);
    }
}
