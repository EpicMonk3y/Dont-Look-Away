using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public Animator blink;
    public float minBlinkTime, maxBlinkTime;
    bool looping = true;

    private void Start()
    {
        StartCoroutine(blinking());
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
