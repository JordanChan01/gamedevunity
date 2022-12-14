using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource bkgMusic;

    private void Awake()
    {
        bkgMusic = transform.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bkgMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
