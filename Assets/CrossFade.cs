using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFade : MonoBehaviour


{
    public Renderer m_Renderer;
    int fadeDirection;
    public bool load;
    // Start is called before the first frame update
    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        StartCoroutine(FadeIn());

    }

    IEnumerator FadeIn()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)  // fade an object and also moves it up or down based on fade direction
        {

            Color fadeColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = fadeColor.a - (fadeDirection * 0.5f * Time.deltaTime);

            fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
            m_Renderer.material.color = fadeColor;


            if (this.GetComponent<Renderer>().material.color.a < 0) { load = true; }

            yield return null;
        }

        IEnumerator FadeOut()
        {
            while (this.GetComponent<Renderer>().material.color.a < 1)  // fade an object and also moves it up or down based on fade direction
            {

                Color fadeColor = this.GetComponent<Renderer>().material.color;
                float fadeAmount = fadeColor.a + (0.5f * Time.deltaTime);

                fadeColor = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAmount);
                m_Renderer.material.color = fadeColor;


                if (this.GetComponent<Renderer>().material.color.a > 0) { load = true; }

                yield return null;
            }
        }


    }
}
