using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstRoomEvent : MonoBehaviour
{
    [Header("1st Room")]
   public AudioController audioController;
    public AudioSource scream;
   public GameObject first_Room_Trigger;
   public Animator first_Room_Door;
   public GameObject keyNeeded;
    public bool isDone;

    // Start is called before the first frame update
    void Start()
    {
       isDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
        if(isDone)
        {
            GetComponent<FirstRoomEvent>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FirstRoomTrigger")
        {
            Debug.Log("test");
            audioController.PlaySlamDoorSFX();
            first_Room_Door.SetBool("slam", true);
            scream.Play();
            Destroy(other.gameObject);
        }
    }

    void OpenDoor()
    {
        if (keyNeeded.activeInHierarchy == false)
        {
            audioController.PlayOpenDoorSFX();
            first_Room_Door.SetBool("open", true);
            isDone = true;
        }
    }
}
