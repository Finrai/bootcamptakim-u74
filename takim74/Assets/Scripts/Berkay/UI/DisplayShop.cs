using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShop : MonoBehaviour
{
    public GameObject shop;
    public float shopRadius;
    public LayerMask player;
    private void Update()
    {
        displayShop();
        
    }

    private void displayShop()
    {
        shop.SetActive((Physics.CheckSphere(transform.position,shopRadius,player)));

        if(shop.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
