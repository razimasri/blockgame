using UnityEngine;
using UnityEngine.UI;

public class QuickMenu : MonoBehaviour
{
    public GameObject[] qMenuObjects;

    public void QMenu(bool InGameMenuUp)
    {
        foreach (GameObject qMenuObj in qMenuObjects)
        {

            qMenuObj.SetActive(InGameMenuUp ? false : true);

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle tog = GetComponent<Toggle>();

            tog.isOn = tog.isOn ? false : true;

        }
    }


}

