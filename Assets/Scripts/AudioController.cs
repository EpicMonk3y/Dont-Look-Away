using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip openDoorSFX;
    public AudioClip lockedDoorSFX;
    public AudioClip slamDoorSFX;
    public AudioClip pickUpKeySFX;
    public AudioClip flashLightOnSFX;
    public AudioClip flashLightOffSFX;
    public AudioClip batteryPickUpSFX;
    public AudioClip notePickUpSFX;
    public AudioClip jumpScareSFX;
    public AudioClip breathingHeavySFX;
    public AudioClip jumpScareFinalSFX;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayOpenDoorSFX()
    {
        audioSource.PlayOneShot(openDoorSFX, 1f);
    }

    public void PlayLockedDoorSFX()
    {
        audioSource.PlayOneShot(lockedDoorSFX, 1f);
    }

    public void PlaySlamDoorSFX()
    {
        audioSource.PlayOneShot(slamDoorSFX, 1f);
    }

    public void PlayPickUpKeySFX()
    {
        audioSource.PlayOneShot(pickUpKeySFX, 1f);
    }

    public void PlayFlashLightOnSFX()
    {
        audioSource.PlayOneShot(flashLightOnSFX, 1f);
    }

    public void PlayFlashLightOffSFX()
    {
        audioSource.PlayOneShot(flashLightOffSFX, 1f);
    }

    public void PlaybatteryPickUpSFX()
    {
        audioSource.PlayOneShot(batteryPickUpSFX, 1f);
    }

    public void PlayNotePickUpSFX()
    {
        audioSource.PlayOneShot(notePickUpSFX, 1f);
    }

    public void PlayJumpScareSFX()
    {
        audioSource.PlayOneShot(jumpScareSFX, 1f);
    }

    public void PlayBreathingHeavySFX()
    {
        audioSource.PlayOneShot(breathingHeavySFX, 1f);
    }

    public void PlayJumpScareFinalSFX()
    {
        audioSource.PlayOneShot(jumpScareFinalSFX, 1f);
    }
}
