using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject playerLook;
    public Rigidbody rb;
    public GameObject notesUI;

    public GameObject pickUpText;

    public AudioController audioController;

    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        notesUI.SetActive(false);
        pickUpText.SetActive(false);

        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
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

    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            notesUI.SetActive(true);
            player.GetComponent<FirstPersonMovement>().enabled = false;
            playerLook.GetComponent<FirstPersonLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ExitNote()
    {
        notesUI.SetActive(false);
        player.GetComponent<FirstPersonMovement>().enabled = true;
        playerLook.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
