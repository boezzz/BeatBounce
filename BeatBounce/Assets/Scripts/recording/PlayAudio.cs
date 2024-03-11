using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip soundToPlay;
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(soundToPlay);
        }
        else
        {
            Debug.LogError("AudioSource component is null!");
        }
    }
}
