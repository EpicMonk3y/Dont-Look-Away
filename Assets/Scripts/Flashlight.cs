using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class Flashlight : MonoBehaviour
{
    public Light _light;
    public TMP_Text _batteryLife;
    public TMP_Text _batteries;
    public AudioController audioController;

    public float batteries = 0;
    public float lifetime;


    // Start is called before the first frame update
    void Start()
    {
        _batteryLife.text = "Flashlight: " + lifetime + "%";
    }

    // Update is called once per frame
    void Update()
    {
        ToggleFlashLight();
    }

    private void ToggleFlashLight()
    {
        _batteryLife.text = "Flashlight: " + lifetime.ToString("F0") + "%";
        _batteries.text = "Batteries: " + batteries.ToString();

        if (Input.GetButtonDown("Toggle FlashLight"))
        {
            if (_light.enabled)
            {
                audioController.PlayFlashLightOffSFX();
                _light.enabled = false;
            }
            else
            {
                audioController.PlayFlashLightOnSFX();
                _light.enabled = true;
            }
        }

        if (_light.enabled)
        {
            lifetime -= 1 * Time.deltaTime;
        }

        if (lifetime <= 0 && batteries <= 0)
        {
            _light.enabled = false;
            lifetime = 0;
        }

        if (lifetime <= 0 && batteries >= 1)
        {
            lifetime += 50;
            batteries--;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }

        if (batteries <= 0)
        {
            batteries = 0;
        }
    }
}
