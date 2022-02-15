using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManger : MonoBehaviour
{
    public GameObject playButton;
    public GameObject pauseButton;
    public Text scoreText;
    int score = 0;
    private void Start()
    {
        scoreText.text = score.ToString();
    }
    public void play()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void pause()
    {
        pauseButton.SetActive(false);
        playButton.SetActive(true);

        Time.timeScale = 0;
    }
}
