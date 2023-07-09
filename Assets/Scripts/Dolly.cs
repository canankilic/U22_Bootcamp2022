using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolly : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    private float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    public bool Turned = false;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    
    private void FixedUpdate()
    {
        if (!Turned)
        { 
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, Character.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if (Turned)
        {
            Vector3 targetPosition = new Vector3(Character.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
