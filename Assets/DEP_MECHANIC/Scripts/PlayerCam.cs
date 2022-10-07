using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX, sensY;
    public Transform orientation;
    float xRotation, yRotation;
    public Camera playerCam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")* Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        //original:
        //origin.transform = Quaternion.Euler(xRotation,yRotation,90f);
        playerCam.transform.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        transform.rotation = Quaternion.Euler(0,yRotation,0);

        //transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
