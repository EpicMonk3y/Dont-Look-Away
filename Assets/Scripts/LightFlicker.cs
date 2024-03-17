using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light _light;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight();
    }

    void FlickerLight()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0)
        {
            _light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}
