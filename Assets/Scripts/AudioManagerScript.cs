using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio.PlayOneShot(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
