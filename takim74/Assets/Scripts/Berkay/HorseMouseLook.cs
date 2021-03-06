using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMouseLook : MonoBehaviour
{
    
    public float mouseSensivity;
    private float mouseX;
    private float mouseY;
    private Transform playerBody;
    private float verticalRotation; 
    
    void Start()
    {
        playerBody = gameObject.transform.parent;
    }

    
    void Update()
    {
        GetMouseInput();
        HorizontalLook();
        VerticalLook();
 
    }
    void GetMouseInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime; 
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
    }
    void HorizontalLook()
    {
        playerBody.Rotate(Vector3.up * mouseX);
    }
    void VerticalLook()
    {
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(-90f, verticalRotation, 90f); 
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
