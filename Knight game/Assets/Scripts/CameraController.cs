using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variables
    [SerializeField] private float mouseSensitivity;
    

    //References

    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
        /*
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;   //Lock the mouse in the middle of screen 
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
           
        }
        */
    }

    private void Update()
    {
       Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);
    }
}
