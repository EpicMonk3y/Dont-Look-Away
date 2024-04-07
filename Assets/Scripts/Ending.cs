using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject noteNeeded;
    public GameObject enemy;
    public ReadNotes readNotes;
    public GameObject BathhroomTriggerMain;
    public Animator lunchRoomDoor;


    

    // Update is called once per frame
    void Update()
    {
       
    }

   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BathRoomTrigger")
        {
            BathhroomTriggerMain.SetActive(true);
        }
        else if((other.gameObject.tag == "BathRoomTrigger2"))
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            lunchRoomDoor.Play("Lunch Room Door Idle");
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        enemy.SetActive(true);
    }
}
