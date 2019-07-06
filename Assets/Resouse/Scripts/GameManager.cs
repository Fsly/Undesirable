using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public float totalTime;
    public Slider totalTimeSlider;

    public int score;

    public bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnd)
        {
            GameControl();
        }
    }

    public void GameControl()
    {
        if (totalTime <= 0)
        {
            //游戏结束
            Debug.Log("GameOver");
            isEnd = true;
        }
        else
        {
            totalTime -= Time.deltaTime;
            totalTimeSlider.value = totalTime;
        }

        if (score == 5)
        {
            //游戏成功结束
            Debug.Log("GameFinished");
            isEnd = true;
        }
    }

    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void quit()
    {
        Application.Quit();
    }
}
