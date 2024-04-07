using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGameController : MonoBehaviour
{
    public bool settingsActive = false;
    public GameObject settings;
    public FirstPersonMovement firstPersonMovement;
    public SeeEnemy seeEnemy;
    public FirstPersonLook firstPersonLook;

    private void Update()
    {
        if (Input.GetButtonDown("Settings")){

            if (!settingsActive)
            {
                openSettings();
            }
        }
            
        
    }

    public void openSettings()
    {
        Cursor.lockState = CursorLockMode.None;
        settings.SetActive(true);
        firstPersonLook.enabled = false;
        seeEnemy.enabled = false;
        firstPersonMovement.enabled = false;
        settingsActive = true;
        Time.timeScale = 0f;
    }

    public void closeSettings()
    {
        Cursor.lockState = CursorLockMode.Locked;
        settings.SetActive(false);
        firstPersonLook.enabled = true;
        seeEnemy.enabled = true;
        firstPersonMovement.enabled = true;
        settingsActive = false;
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
