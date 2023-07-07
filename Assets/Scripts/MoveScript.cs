using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed = 2f;
    private float lerpTime = 0.02f;
    private float rotationSpeed = 5f;
    private Rigidbody rigi;
    private Animator anim;
    private Vector3 movement;
    private float currentMovement = 0f;
    public GameObject Dolly;
    
    
    void Start()
    {
        
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        
        moveHorizontal = Input.GetAxisRaw("Vertical");
        moveVertical = Input.GetAxisRaw("Horizontal");
        movement = new Vector3(moveHorizontal, 0.0f, -moveVertical);
            
        
        float targetMovement;
        if (movement.sqrMagnitude > 0)
        {
            targetMovement = 1f;
        }
        else
        {
            targetMovement = 0f;
        }

        currentMovement = Mathf.Lerp(currentMovement, targetMovement, lerpTime);
        anim.SetFloat("Movement", currentMovement);
    }

    void FixedUpdate()
    {
        rigi.velocity = movement * speed;
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    
    

    
}