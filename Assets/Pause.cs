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
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPause && Input.GetKeyDown(KeyCode.P))
        {
            PauseFrame.SetActive(true);
            isPause = true;
            Time.timeScale = 0;
        }
        if (isPause && Input.GetKeyDown(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Main");
        }
        if (isPause && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("StartInterface");
        }
        if (isPause && Input.GetKeyDown(KeyCode.C))
        {
            PauseFrame.SetActive(false);
            isPause = false;
            Time.timeScale = 1;
        }
    }
}
