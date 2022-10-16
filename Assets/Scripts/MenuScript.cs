using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GoToEx()
    {
        SceneManager.LoadScene("RunningScene");
    }
    public void GoToDemo()
    {
        SceneManager.LoadScene("Demo");
    }
    public void GoToFast()
    {
        SceneManager.LoadScene("Fast");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
