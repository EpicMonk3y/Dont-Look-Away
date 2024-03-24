using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light _light;

    public Material[] material;
    Renderer rend;
    public int x;
    public AudioSource lightSFX;
    public float MinTime;
    public float MaxTime;
    public float Timer;

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
        rend = GetComponentInParent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight();
        rend.sharedMaterial = material[x];
    }

    void FlickerLight()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
            x = 0;
        }
        if(Timer <= 0)
        {
            _light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
            lightSFX.Play();
            x = 1;
        }
    }
}
