using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueSystem : MonoBehaviour
{
    public AudioClip[] voiceClips;
    public AudioSource audioSource;
    public bool isPlaying = false;

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            isPlaying = false;
        }
    }

    public void PlayVoice(int clip)
    {
        audioSource.PlayOneShot(voiceClips[clip], 1f);
        isPlaying = true;
    }

}
