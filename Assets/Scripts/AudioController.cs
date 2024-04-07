using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
    public AudioClip uiClickSFX;

    [SerializeField] Slider sFXVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    //[SerializeField] TextMeshProUGUI volumeTextUI = null;
    [SerializeField] AudioMixer sfx;
    [SerializeField] AudioMixer music;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSFXVolume();
            SetMusicVolume();
        }
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
        audioSource.PlayOneShot(jumpScareFinalSFX, 0.5f);
    }

    public void PlayUIClickSFX()
    {
        audioSource.PlayOneShot(uiClickSFX, 1f);
    }



    public void SetSFXVolume()
    {
        float volume = sFXVolumeSlider.value;
        sfx.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        music.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        sFXVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

        SetSFXVolume();
        SetMusicVolume();
    }
}
