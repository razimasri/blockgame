using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallCollide : MonoBehaviour
{
    
    public GameObject playerEmpty;
    public Transform target;
    public int layerMask;
    

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Wall");
        playerEmpty = GameObject.Find("PlayerEmpty");
        target = playerEmpty.transform.GetChild(1);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.parent != null)
        {
            if (transform.IsChildOf(playerEmpty.transform))
            {
                if (Physics.Raycast(transform.position, target.GetComponent<TargetMove>().move, 0.5f, layerMask))
                {

                    target.GetComponent<TargetMove>().wall = true;//change bool to wall in target move. wall will reset after each input 
                }

            }
        }


    }


}
