using UnityEngine;
using UnityEngine.UI;

public class CameraSelect : MonoBehaviour
{
    public Sprite[] cameraSprites;
    private Image currentSprite;
    //public Camera Top, Side;
    public Camera[] Cameras;
    private int cam;


    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<Image>();
        cam = 0;
        Cameras[cam].enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();
        }
    }
    void ChangeCamera()
    {
        Cameras[cam].enabled = false;
        cam++;
        if (cam == Cameras.Length) cam = 0;
        Cameras[cam].enabled = true;
    }
}
