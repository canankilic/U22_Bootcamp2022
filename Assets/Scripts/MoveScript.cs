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
    private Animator dollyanim;
    private Vector3 movement;
    private float currentMovement = 0f;
    public GameObject Dolly;
    [SerializeField] private GameObject TurnCorner;
    private int TurnCount = 0;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        dollyanim = Dolly.GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        if (Dolly.GetComponent<Dolly>().Turned)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Vertical");
            moveVertical = Input.GetAxisRaw("Horizontal");
            movement = new Vector3(moveHorizontal, 0.0f, -moveVertical);
        }

        float targetMovement = movement.sqrMagnitude > 0 ? 1f : 0f;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            Dolly.GetComponent<Dolly>().Turned = !Dolly.GetComponent<Dolly>().Turned;
            TurnCount++;

            if (TurnCount == 1)
            {
                dollyanim.SetTrigger("Turn");
            }
            else if (TurnCount % 2 == 0)
            {
                dollyanim.SetTrigger("OtherTurn");
            }
            else
            {
                dollyanim.SetTrigger("TurnBack");
            }
        }
    }
}
