using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolly : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    private float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    
    
    private void FixedUpdate()
    {
        
        Vector3 targetPosition = new Vector3(Character.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
    }
}