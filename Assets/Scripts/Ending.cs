using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject noteNeeded;
    public GameObject enemy;
    public ReadNotes readNotes;


    

    // Update is called once per frame
    void Update()
    {
        if (noteNeeded.activeInHierarchy)
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            if(readNotes.lastNoteIsDone)
            {
                Debug.Log("test");
                StartCoroutine(wait());
                

            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        enemy.SetActive(true);
    }
}
