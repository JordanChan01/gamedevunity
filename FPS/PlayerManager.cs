using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public float health = 100;
    public TextMeshProUGUI healthText;
    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;
        healthText.text = health.ToString() + " Health";

        if (health <= 0)
        {
            gameManager.EndGame();
        }


    }
    
}
