using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{

    [SerializeField] AudioClip[] sounds;

    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Sounds();
        }
    }

    void Sounds()
    {
        AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        myAudioSource.PlayOneShot(clip);

    }

}
