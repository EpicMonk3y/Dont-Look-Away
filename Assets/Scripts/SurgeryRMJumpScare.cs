using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryRMJumpScare : MonoBehaviour
{
    public AudioController audioController;
    public GameObject surgery_Room_Trigger;
    public GameObject keyNeeded;
    public Animator surgery_Room_Anim;
    public bool isDone;
    

    
    void Start()
    {
        isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDone)
        {
            GetComponent<SurgeryRMJumpScare>().enabled = false;
        }

        if (keyNeeded.activeInHierarchy == false)
        {
            surgery_Room_Trigger.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SurgeryRoomJSTrigger")
        {
            if (keyNeeded.activeInHierarchy == false)
            {
                audioController.PlayJumpScareSFX();
                audioController.PlayBreathingHeavySFX();
                surgery_Room_Anim.Play("Mannequin Jump Scare 1");
                isDone = true;
                surgery_Room_Trigger.SetActive(false);
            }
        }
         
    }
}
