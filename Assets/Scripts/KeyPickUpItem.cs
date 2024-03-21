using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUpItem : MonoBehaviour
{
    public GameObject pickupItem;
    public GameObject pickUpText;
    public GameObject inventoryOB;
    public AudioSource keyPickUpSFX;

    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        inventoryOB.SetActive(false);
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
            keyPickUpSFX.Play();
            inventoryOB.SetActive(true) ;
            pickUpText.SetActive(false);
            pickupItem.SetActive(false);
        }
    }
}
