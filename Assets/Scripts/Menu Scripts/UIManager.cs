using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] string currentLevel;
    [SerializeField] TMP_Text _levelText;
    [SerializeField] Toggle menu;
    // Start is called before the first frame update
    void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
