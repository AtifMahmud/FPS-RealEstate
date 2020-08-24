using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_CameraMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float wasdSpeed = 0.001f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float posX;
    private float posY;
    private float posZ;

    private bool rotate;
    GameObject canvas;
    GameObject currentInFocus;

    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
        canvas = GameObject.Find("Canvas");
        canvas.active = false;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateCameraRotation();
        UpdateCameraPosition();
        OnMouseDown();
    }

    void UpdateCameraRotation()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void UpdateCameraPosition()
    {
        if (Input.GetAxis("Vertical") != 0)
            if (Input.GetKeyDown(KeyCode.W))
                transform.Translate(Vector3.back * wasdSpeed, Space.World);

        if (Input.GetAxis("Horizontal") != 0)
            transform.Translate(Vector3.left * wasdSpeed, Space.World);

        posX = transform.position.x;
        posZ = transform.position.z;
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) 
            {
                Debug.Log(hit.transform.gameObject.name);
                currentInFocus = hit.transform.gameObject;
                canvas.active = true;

            }
        }
    }

    public void HandleInput(int val)
    {
        if (val == 1)
        {
            UpdateMaterialWithRed();

        } 

        if (val == 2)
        {
            UpdateMaterialWithBlue();
        } 
    }

    public void UpdateMaterialWithRed()
    {
        currentInFocus.GetComponent <Renderer>().materials[0].color = Color.red;
    }

    public void UpdateMaterialWithBlue()
    {
        currentInFocus.GetComponent<Renderer>().materials[0].color = Color.blue;
    }

}

