﻿using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;

    [SerializeField] Slider mouseSensSlider;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        if (PlayerPrefs.HasKey("sensitvity"))
        {
            LoadSensitivity();
        }
        else
        {
            SetSensitivity();
        }

        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }



    public void SetSensitivity()
    {
        float sensitivity = mouseSensSlider.value;
        this.sensitivity = sensitivity;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }

    private void LoadSensitivity()
    {
        mouseSensSlider.value = PlayerPrefs.GetFloat("sensitivity");
        SetSensitivity();
    }
}
