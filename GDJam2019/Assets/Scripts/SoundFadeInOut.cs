using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundFadeInOut : MonoBehaviour
{
    public float fadeInTime, fadeOutTime;

    private enum States
    {
        FadeIn,
        Loop,
        FadeOut
    }

    private States state = States.Loop;
    private AudioSource audioSource;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.FadeIn:
                timer += Time.deltaTime;
                if(timer >= fadeInTime)
                {
                    timer = fadeInTime;
                    state = States.Loop;
                }

                audioSource.volume = timer / fadeInTime;
                break;
            case States.Loop:
                break;
            case States.FadeOut:
                timer += Time.deltaTime;
                if (timer >= fadeOutTime)
                {
                    timer = fadeOutTime;
                    state = States.Loop;
                }

                audioSource.volume = 1f - (timer / fadeOutTime);
                break;
            default:
                break;
        }
    }

    public void Play()
    {
        state = States.FadeIn;
        timer = audioSource.volume * fadeInTime;
    }

    public void Stop()
    {
        state = States.FadeOut;
        audioSource.volume = 1;
        timer = (1f - audioSource.volume) * fadeOutTime;
    }

    public bool isPlaying()
    {
        return (state == States.Loop || state == States.FadeIn) && (audioSource.volume > 0f);
    }
}
