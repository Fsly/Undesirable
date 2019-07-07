using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject PauseFrame;
    public bool isPause=false;

    // Start is called before the first frame update
    void Start()
    {
        PauseFrame.SetActive(false);
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause && Input.GetKeyDown(KeyCode.P))
        {
            
        }
        if (isPause && Input.GetKeyDown(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Main");
        }
        if (isPause && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("log");
        }
        if (isPause && Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("log");
        }
    }
}
