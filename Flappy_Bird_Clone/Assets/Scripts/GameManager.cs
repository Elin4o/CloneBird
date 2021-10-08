using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject scoreCanvas;
    public Text highscoreText;

    public GameObject player;
    public static GameManager Instance { get; private set; }

    private int _score;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
        }

    }

    private void Start()
    {
        Instance = this;
        Time.timeScale = 1;
        SetRatio(9, 16);
    }

    void SetRatio(float w, float h)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > w / h)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (w / h)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (h / w)), true);
        }
    }

    public void GameOver()
    {
        if (Score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", Score);
        }

        highscoreText.text = "" + PlayerPrefs.GetInt("highscore");
        gameCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        
        Time.timeScale = 0;

        Destroy(player);
    }

    public void Play()
    {
        SceneManager.LoadScene(0);
        highscoreText.text = "" + PlayerPrefs.GetInt("highscore");
        gameCanvas.SetActive(false);
    }

    public void doExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
