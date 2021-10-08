using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRandomMovement : MonoBehaviour
{
    public Vector3[] move = { Vector3Int.right, Vector3Int.left, Vector3Int.forward, Vector3Int.back, Vector3Int.right, Vector3Int.left, Vector3Int.forward, Vector3Int.back };
    private Transform player;
    public float sec;
    public GameObject[] cubes;
    private Vector3 origin;
    Vector3 previousMove = Vector3.zero;
    Vector3 thisMove =Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        

        player = transform.parent.GetChild(0); //bad hack to make move code work nice

        for(int i = 0; i <15; i++) //sadly same colours cubes do not trigger
        {
            Instantiate(cubes[Random.Range(0, cubes.Length)], new Vector3Int(Random.Range(1, 10), 0, Random.Range(-6, 6)), new Quaternion(0, 0, 0, 0));
        }
        for (int i = 0; i < 15; i++)
        {
            Instantiate(cubes[Random.Range(0, cubes.Length)], new Vector3Int(Random.Range(-10, -1), 0, Random.Range(-6, 6)), new Quaternion(0, 0, 0, 0));
        }

    }

    // Update is called once per frame
    void Update()
    {
        sec = sec + Time.deltaTime;

        if (transform.position == player.position &&  sec >0.5)
        {
            int array = Random.Range(0, move.Length);
            origin = transform.position;
            thisMove=move[array];
            if (previousMove + thisMove == Vector3.zero) {

                thisMove = Quaternion.Euler(0, 90, 0)*thisMove;
            }

            transform.Translate(thisMove); 
            sec = 0;
            previousMove = thisMove;

        }
        if (!Physics.Raycast(transform.position, Vector3.down) | transform.position.x > 10 | transform.position.z > 5 | transform.position.x < -10 | transform.position.z < -6)
        {
            transform.position = origin;

        }

        if(transform.position.x > 6)
        {
           move[4]=Vector3.left;
            move[5] = Vector3.left;
        }

        if (transform.position.x <- 6)
        {
            move[4] = Vector3.right;
            move[5] = Vector3.right;
        }

        if (transform.position.z > 4)
        {
            move[6] = Vector3.back;
            move[7] = Vector3.back;
        }

        if (transform.position.z < -4)
        {
            move[6] = Vector3.forward;
            move[7] = Vector3.forward;
        }



    }
}
