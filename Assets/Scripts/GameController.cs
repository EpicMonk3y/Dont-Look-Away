using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject settings;
    public Button startButton;
    public Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openSettings()
    {
        settings.SetActive(true);
        startButton.enabled = false;
        settingsButton.enabled = false;
    }

    public void closeSettings()
    {
        settings.SetActive(false);
        startButton.enabled = true;
        settingsButton.enabled = true;
    }
}
