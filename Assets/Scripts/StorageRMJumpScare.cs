using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageRMJumpScare : MonoBehaviour
{
    public AudioController audioController;
    public GameObject storage_Room_Trigger;
    public GameObject noteNeeded;
    public Animator storage_Room_Anim;
    public bool isDone;
    public bool interactedWithNote;
    // Start is called before the first frame update

    
    void Start()
    {
        isDone = false;
        interactedWithNote = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDone)
        {
            GetComponent<StorageRMJumpScare>().enabled = false;
        }

        if (noteNeeded.activeInHierarchy == true)
        {
            interactedWithNote = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StorageRoomTrigger")
        {
            if (interactedWithNote == true)
            {
                audioController.PlayJumpScareSFX();
                audioController.PlayBreathingHeavySFX();
                storage_Room_Anim.Play("Mannequin Jump Scare 1");
                isDone = true;
                Destroy(other.gameObject);
            }
        }
         
    }
}
