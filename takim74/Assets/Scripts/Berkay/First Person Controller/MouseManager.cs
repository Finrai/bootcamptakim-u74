using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseManager : MonoBehaviour
{
   
   public Canvas shop; // canvas
   public Canvas playerInventoryCanvas;
   public MouseLook mouseLook;
   public PlayerMovement playerMovement;

   private float moveSpeedInitial;
   private float mouseSensInitial;

   public GameObject audioSources;

   private void Start()
   {
       audioSources = transform.GetChild(0).gameObject;

       moveSpeedInitial = playerMovement.moveSpeed;
       mouseSensInitial = mouseLook.mouseSensivity;

       Cursor.lockState = CursorLockMode.Locked;

      
       shop.enabled = false;
       
   }

   private void Update()
   {
       if(shop.enabled == true)
       {
           Cursor.lockState = CursorLockMode.None;

           playerMovement.moveSpeed = 0;
           mouseLook.mouseSensivity = 0;
       }
       
   }

   private void OnTriggerStay(Collider other)
   {
       if(other.CompareTag("Player") == true)
       {
           if(Input.GetKey(KeyCode.E) && shop.enabled == false && playerInventoryCanvas.enabled == false)
           {    
                shop.enabled = true;
                OpenShopSound();
           }
       }
   }

   public void CloseButton()
   {

        playerMovement.moveSpeed = moveSpeedInitial;

        mouseLook.mouseSensivity = mouseSensInitial; 

        shop.enabled = false;

       
        Cursor.lockState = CursorLockMode.Locked;

        playerMovement.moveSpeed = moveSpeedInitial;

        mouseLook.mouseSensivity = mouseSensInitial;

        CloseShopSound();
       
   }

   public void OpenShopSound() 
    {
        AudioSource openShopSound = audioSources.transform.GetChild(Random.Range(5,9)).gameObject.GetComponent<AudioSource>();
        AudioSource doorOpen = audioSources.transform.GetChild(9).gameObject.GetComponent<AudioSource>();
        doorOpen.Play();
        openShopSound.Play();
    }

    public void CloseShopSound() 
    {
        AudioSource doorShop = audioSources.transform.GetChild(10).gameObject.GetComponent<AudioSource>();
        AudioSource thanks = audioSources.transform.GetChild(3).gameObject.GetComponent<AudioSource>();
        doorShop.Play();
    }
}

