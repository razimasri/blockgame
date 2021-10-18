using UnityEngine.UI;
using UnityEngine;

public class sliderAwake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetInt("vol");
    }

}
