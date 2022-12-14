using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;
    private AudioSource zombiesHitSound;

    private void Awake()
    {
        zombiesHitSound = GetComponent<AudioSource>();
    }


    public void Hit(float damage)
    {
        
        Debug.Log("hit");
        
        health -= damage;
        if (health<=0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        gameManager.enemiesAlive--;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
     


    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else 
        
            enemyAnimator.SetBool("isRunning", false);
        }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
            zombiesHitSound.Play();
        }
    }





}


    


 