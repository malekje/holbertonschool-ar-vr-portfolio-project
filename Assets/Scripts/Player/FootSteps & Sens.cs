using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    public AudioSource jumpingSound;

    public float lookSensitivity = 2.0f;

    void Update()
    {
        // Check for keyboard input
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Check for analog input on the controller
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isControllerMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        // Enable/disable footsteps sound based on input
        if (isMoving || isControllerMoving)
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }

        // Check for jumping input
        if ((Gamepad.current != null && Gamepad.current.buttonSouth.isPressed) || Input.GetKeyDown(KeyCode.Space))
        {
            // Play jumping sound
            jumpingSound.Play();
        }

        // Looking around with right analog stick input
        Vector2 lookInput = Gamepad.current != null ? Gamepad.current.rightStick.ReadValue() : Vector2.zero;
        LookAround(lookInput * lookSensitivity);
    }

    void LookAround(Vector2 lookDelta)
    {
        // Adjustment for the rotation based on the horizontal input
        transform.Rotate(Vector3.up * lookDelta.x); 
        
    }
}
