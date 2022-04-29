using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement, verticalMovement;
    public float moveSpeed;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 playerVelocity;
    public Transform groundChecker;
    private float groundRadius = 0.4f;
    public LayerMask groundMask;
    private float gravity = -9.81f;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Gravity();

        GetPlayerInput();
        MovePlayer();
        
    }
    void GetPlayerInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }
    void MovePlayer()
    {
        moveDirection = (transform.right * horizontalMovement) + (transform.forward * verticalMovement);
        controller.Move(moveDirection * moveSpeed);
    }
    void Gravity()
    {
        playerVelocity.y += gravity * Time.deltaTime;

        if(Physics.CheckSphere(groundChecker.position,groundRadius,groundMask) && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
