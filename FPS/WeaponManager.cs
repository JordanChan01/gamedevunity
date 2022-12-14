using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    public float health = 100f;
    public Animator playerAnimator;
    public LayerMask zombieLayer;
    private AudioSource shootSound;

    private void Awake()
    {
        shootSound = GetComponent<AudioSource>();
    }

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Shoot"); 
            Shoot();
            shootSound.Play();
        }
    }


    void Shoot()
    {

        playerAnimator.SetBool("isShooting", true);
        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range, zombieLayer))
        {
            Debug.Log(hit.collider.gameObject.name);

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.Hit(damage);
                Debug.Log("Enemy Detected");
            }

        }
    }


}
