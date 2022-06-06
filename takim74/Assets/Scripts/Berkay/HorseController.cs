using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    public bool onHorse = true;

    public bool pressed;

    private bool triggered;

    public  GameObject horseCamera;

    public GameObject player;
    
    public GameObject playerCamera;

    public PlayerMovement playerMovement;

    public HorseMovement horseMovement;

    private Transform initialPositionOfPlayer;
    public Transform onHorseTransform;


    
    private void Update()
    {
        Debug.Log(triggered);

        if(triggered && Input.GetKeyDown(KeyCode.R) && onHorse == false)
        {
            onHorse = true;
        }

        if(triggered && Input.GetKeyDown(KeyCode.T) && onHorse == true)
        {
            onHorse = false;
        }

        if(onHorse == true) 
        {
            playerMovement.moveSpeed = 0;
            horseMovement.moveSpeed = 8;

            

            player.transform.position = onHorseTransform.position;


        }
        else
        {
            playerMovement.moveSpeed = 6;
            horseMovement.moveSpeed = 0;
        }

        playerCamera.SetActive(!onHorse);
        horseCamera.SetActive(onHorse);

        
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggered = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    public void SetOnHorse()
    {
        onHorse = !onHorse;
    }

    
   
}
