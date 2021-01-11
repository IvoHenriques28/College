using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;//mouse sensitivity we want to apply

    public Transform playerBody; // reference to the player's body

    float xRotation = 0f; //rotation in the X Axis we want to do

    //at the Start, we want our cursor to dissapear from the screen
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        //get the Inputs of our mouse in both the X and Y Axis, multiplying them by the mouse sensitivity previously set
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

        //our rotation in the X Axis is gonna be the inverse of our mouse movement in the Y Axis, otherwise we would have swaped motions
        xRotation -= mouseY;

        //limiting the rotation in the X Axis so that it isn't possible to do a full 360 rotation in the Y Axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotating the player's local position in the X Axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //rotating the player around the Y Axis (using a different method since now we are allowed to do 360 rotations)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
