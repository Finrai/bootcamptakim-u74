using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementx : MonoBehaviour
{
    [SerializeField] float speedBase = 40f;
    [SerializeField] float speed = -15f;
    float gravity = -10.81f;


    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speedBase * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speedBase * Time.deltaTime;


        rigid.velocity = new Vector3(speed, gravity, horizontal * speedBase);



    }
}
