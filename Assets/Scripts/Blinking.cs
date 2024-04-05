using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public Animator blink;
    public float minBlinkTime, maxBlinkTime;
    bool looping = true;
    public bool isPlaying = false;

    private void Start()
    {
        
        StartCoroutine(blinking());

    }

    private void Update()
    {

        if (blink.GetCurrentAnimatorStateInfo(0).IsName("Eyes Idle"))
        {
            isPlaying = false;
        }
        else
        {
            isPlaying = true;
        }
    }

    IEnumerator blinking()
    {
        while(looping)
        {
            yield return new WaitForSeconds(Random.Range(minBlinkTime, maxBlinkTime));
            blink.SetTrigger("blink");
        }
        
    }
}
