using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSliderControls : MonoBehaviour
{

    [SerializeField] Slider sFXVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    //[SerializeField] TextMeshProUGUI volumeTextUI = null;
    [SerializeField] AudioMixer audioMixer;
    // Start is called before the first frame update

    public void SetSFXVolume()
    {
        float volume = sFXVolumeSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
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
