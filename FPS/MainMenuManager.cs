using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

    private AudioSource bgm;

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        bgm.Play();
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
