using UnityEngine;

public class MenuPlayerEmpyerManager : MonoBehaviour
{
    [SerializeField] GameObject Empty;   
    void Update()
    {
        if (transform.childCount == 0)
        {
            Instantiate(Empty, transform);
        }
    }
}
