
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameObject playerEmpty;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        playerEmpty = GameObject.Find("PlayerEmpty");
        player = playerEmpty.transform.GetChild(0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(player, Vector3.up);
    }
}
