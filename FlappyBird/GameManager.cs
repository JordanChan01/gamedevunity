using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    private Spawner spawner;

    public GameObject scoreTextObject;
    TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score; /*{ get; private set; }*/


    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();

        Pause();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public void Play()
    {
        score = 0;
       

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

        
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        
    }


    public void ResetScene()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

}
