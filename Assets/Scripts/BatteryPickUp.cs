using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatteryPickUp: MonoBehaviour
{
    public GameObject flashlight;
    public GameObject pickUpText;
    public AudioSource pickUpSFX;


    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            flashlight.GetComponent<Flashlight>().batteries += 1;
            pickUpSFX.Play();
            pickUpText.SetActive(false);
            inReach = false;
            Destroy(gameObject);
        }
    }
}

