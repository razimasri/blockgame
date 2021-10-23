using System.Collections;
using UnityEngine;


public class MenuRandomMovement : MonoBehaviour
{
    [SerializeField] Vector3[] directions = { Vector3Int.zero, Vector3Int.right, Vector3Int.left, Vector3Int.forward, Vector3Int.back};
    [SerializeField] Transform player, target;
    [SerializeField] GameObject[] cubes;
    private Vector3 previousMove, thisMove; 
    private int[,] array;
    private int layerMask;
    
    


    // TODO: redo the likelyhood of moving back towards the centre
    void Start()
    {
       
        layerMask = LayerMask.GetMask("Wall");
        CubeGenerator();
        StartCoroutine(Moving());
        
    }

    private void CubeGenerator()
    {
        array = new int[21, 21];  // create and 11 by 11 array is there to eliminates spawning like neighbours
                                  //int count = 0;
        int prefabs = cubes.Length;

        for (int row = -10; row < 10; row++)
        {
            for (int column = -10; column < 10; column++)
            {
                //leave the centre square for the player

                int x = column + 10;
                int z = row + 10;
                int cube = Random.Range(0, 25);
                array[x, z] = cube;

                if (cube < prefabs && checkXY(x, z, prefabs))
                {
                    Vector3 spawn = new Vector3Int(column, 0, row);

                    if (!inExcludeZone(spawn))
                    {
                        Instantiate(cubes[cube], new Vector3Int(column, 0, row), new Quaternion(0, 0, 0, 0), transform);
                    }

                }

            }

        }
    }

    private bool checkXY(int x, int z, int prefabs) // not a fan of how this neighbour color check turned out
    {
        
        if (x > 0)
        {
            if (array[x - 1, z] < prefabs-1)
            {
                // Debug.Log("X check " + x + "," + z + "Cube" + array[x - 1, z] + "Cube" + cube);
                return false;
            }
            
            
        }
        if (z > 0)
        {
            if (array[x, z - 1] < prefabs-1)
            {
                // Debug.Log("Y check " + x + "," + z + "Cube" + array[x - 1, z] + "Cube" + cube);
                return false;
            }
        }
       

        return true;
    }
    private bool inExcludeZone (Vector3 spawn){
       
        foreach (Vector3 exclude in directions)
        {
            if (spawn == exclude) return true;
            
        }
        return false;

    }


    public IEnumerator Moving()
    {
        int moves = 0;
        while (moves < 120)
        {

            if (Vector3.Distance(target.position, Vector3.zero) > 6)
            {
                Vector3 centreBias = (Vector3.zero - target.position).normalized;
               
                centreBias = (Mathf.Abs(centreBias.x) > Mathf.Abs(centreBias.z)) ? new Vector3Int(Mathf.RoundToInt(centreBias.x), 0, 0) : new Vector3Int(0, 0, Mathf.RoundToInt(centreBias.z)) ; 
               
                thisMove = centreBias; 
                
            }
            else if (target.position == player.position)
            {
                int m = Random.Range(0, directions.Length);
                
                thisMove = directions[m];
                if (previousMove + thisMove == Vector3.zero)
                {

                    thisMove = Quaternion.Euler(0, 90, 0) * thisMove;
                }
                              
                moves++;
                previousMove = thisMove;
                
            }
            
            
            



            yield return new WaitForSeconds(0.6f);
           
        }
        Destroy(gameObject);




    }

    
    private void Update() // needed to use fixed update or it sometimes flew by. did the fixed update do this? so i need fixed update to ensure attach but I need late or normale update to not collide with walls...
    {
        target.position += thisMove; //had to move down here or i had the issue of cubes not attach OR wall not detected no longer detecting walls
        
        if (CanMove(thisMove, target.position))
        {
            player.position = Vector3.MoveTowards(player.position, target.position, 5 * Time.deltaTime);
        }
        else
        {
            target.position = player.position;

        }
        thisMove = Vector3.zero;


       

    }

    private bool CanMove(Vector3 move, Vector3 target)
    {
        Transform[] playerCubes = player.transform.GetComponentsInChildren<Transform>(); //get componenet expensive to call everyloop so it is cached
        foreach (Transform block in playerCubes)  // TODO: swap to a for loop when you can but keeping this readable for now as a beginner
        {
            if (Physics.Raycast(block.position, move, 0.6f, layerMask))
            {
                return false;
            }
        }
        if (!Physics.Raycast(target, Vector3.down))
        {
            return false;
        }
        return true;
    }
}

