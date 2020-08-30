using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float yRotation = 0f;
    bool mouseMovementAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseMovementAllowed = !mouseMovementAllowed;
            if (Cursor.visible == false)
            {
                Cursor.visible = true;
            }
            else {
                Cursor.visible = false;
            }
           

        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        if (mouseMovementAllowed)
        {
            transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
