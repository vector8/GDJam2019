using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JumpSounds : MonoBehaviour
{
    public AudioClip[] benDeathSounds;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = benDeathSounds[Random.Range(0, benDeathSounds.Length)];
            audioSource.Play();
        }
    }
}
