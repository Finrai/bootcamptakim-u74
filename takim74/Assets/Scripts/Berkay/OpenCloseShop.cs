using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenCloseShop : MonoBehaviour
{
    public GameObject canvas;
    public LayerMask player;

    private void Update()
    {
        canvas.SetActive(Physics.CheckSphere(transform.position,15,player));

        if(canvas.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
