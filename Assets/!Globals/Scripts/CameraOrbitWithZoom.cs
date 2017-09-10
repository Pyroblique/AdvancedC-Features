using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithZoom : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 1f;

    public float distanceMin = 0.5f;
    public float distanceMax = 15f;

    float x = 0f;
    float y = 0f;

    // Use this for initialization
    void Start()
    {
        // Get the current axis of rotation of x and y
        Vector3 angles = transform.eulerAngles;
        // Swap over x and y because of the axis
        x = angles.y;
        y = angles.x;
    }

    void HideCursor(bool isHiding)
    {
        // Is the cursor supposed to be hiding?
        if(isHiding)
        {
            // Hide the cursor
            Cursor.visible = false;
        }
        else
        {
            // Unhide the cursor
            Cursor.visible = true;
        }
    }

    void GetInput()
    {
        // Gather X and Y mouse offset input to rotate camera (by sensitivity)
        x += Input.GetAxis("Mouse X") * sensitivity;
        // Opposite direction for Y because it is inverted
        y -= Input.GetAxis("Mouse Y") * sensitivity;

        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - inputScroll, distanceMin, distanceMax);
    }

    void Movement()
    {
        if(target)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            Vector3 negDistance = new Vector3(0, 0, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.position = position;
            transform.rotation = rotation;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // IF right mouse button is pressed
        if(Input.GetKey(KeyCode.Mouse1))
        {
            // Hide the cursor
            Cursor.visible = false;
            // GetInput()
            GetInput();
        }   
        // ELSE
        else
        {
            // Unhide cursor
            Cursor.visible = true;
        }

        // Movement()
        Movement();
    }
}
