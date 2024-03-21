using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator openDoorAnim;
    public GameObject keyNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openDoorSFX;
    public AudioSource lockedDoorSFX;

    public bool inReach;
    public bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<OpenDoor>().enabled)
        {
            if (other.gameObject.tag == "Reach")
            {
                inReach = true;
                openText.SetActive(true);
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            keyMissingText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown("Interact"))
        {
            keyNeeded.SetActive(false);
            openDoorSFX.Play();
            openDoorAnim.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;

        }
        else if (keyNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            lockedDoorSFX.Play();
            keyMissingText.SetActive(true);
        }
        else if (isOpen)
        {
            GetComponent<OpenDoor>().enabled = false;
        }
    }
}
