using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRandomMovement : MonoBehaviour
{
    public Vector3[] move = { Vector3Int.right, Vector3Int.left, Vector3Int.forward, Vector3Int.back, Vector3Int.right, Vector3Int.left, Vector3Int.forward, Vector3Int.back };
    [SerializeField] Transform player, target;
    public float sec;
    public GameObject[] cubes;
    private Vector3 origin;
    Vector3 previousMove = Vector3.zero;
    Vector3 thisMove = Vector3.zero;
    public int[,] array;
    public int moves;


    // Start is called before the first frame update
    void Start()
    {

        CubeGenerator();
        StartCoroutine(Moving());

    }

    private void CubeGenerator()
    {
        array = new int[21, 21];  // create and 11 by 11 array is there to eliminates spawning like neighbours
                                  //int count = 0;

        for (int row = -10; row < 10; row++)
        {
            for (int column = -10; column < 10; column++)
            {
                //leave the centre square for the player

                int x = column + 10;
                int z = row + 10;
                int cube = Random.Range(0, 25);
                array[x, z] = cube;

                if (cube < 4 && checkXY(x, z, cube))
                {
                    Instantiate(cubes[cube], new Vector3Int(column, 0, row), new Quaternion(0, 0, 0, 0));

                }

            }

        }
    }

    private bool checkXY(int x, int z, int cube)
    {
        


        if (x > 0)
        {
            if (array[x - 1, z] < 4)
            {
                // Debug.Log("X check " + x + "," + z + "Cube" + array[x - 1, z] + "Cube" + cube);
                return false;
            }

        }
        if (z > 0)
        {
            if (array[x, z - 1] < 4 )
            {
                // Debug.Log("Y check " + x + "," + z + "Cube" + array[x - 1, z] + "Cube" + cube);
                return false;
            }
        }
        if (inExcludeZone(x, z)) return false;

        return true;
    }
    private bool inExcludeZone (int x, int z){
       
       // int[,] exclude = { { 10, 10 }, { 9, 10, }, { 10, 9 }, { 11, 10 }, { 10, 11 } };

        for (int i = 9; i < 12; i++)
        {
            for (int j = 9; j < 12; j++)
            {
                if (i == x && j == z) return true;
            }
        }
        return false;
    }


    public IEnumerator Moving()
    {
        while (moves < 120)
        {
            sec = sec + Time.deltaTime;

            if (target.transform.position == player.position && sec > 1)
            {
                int m = Random.Range(0, move.Length);
                origin = target.transform.position;
                thisMove = move[m];
                if (previousMove + thisMove == Vector3.zero)
                {

                    thisMove = Quaternion.Euler(0, 90, 0) * thisMove;
                }

                target.transform.Translate(thisMove);
                sec = 0;
                moves++;
                previousMove = thisMove;
                

            }
            if (!Physics.Raycast(target.transform.position, Vector3.down) | target.transform.position.x > 10 | target.transform.position.z > 5 | target.transform.position.x < -10 | target.transform.position.z < -6)
            {
                target.transform.position = origin;

            }

            if (target.transform.position.x > 6)
            {
                move[4] = Vector3.left;
                move[5] = Vector3.left;
            }

            if (target.transform.position.x < -6)
            {
                move[4] = Vector3.right;
                move[5] = Vector3.right;
            }

            if (target.transform.position.z > 4)
            {
                move[6] = Vector3.back;
                move[7] = Vector3.back;
            }

            if (target.transform.position.z < -4)
            {
                move[6] = Vector3.forward;
                move[7] = Vector3.forward;
            }


            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

        player.position = Vector3.MoveTowards(player.position, target.position, 5 * Time.deltaTime);
        



    }
}

