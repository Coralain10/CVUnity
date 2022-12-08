using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//StairClimb
public class OnStair : MonoBehaviour
{
    Collider2D otherOn;
    short speed = 16;
    float upInput;
    bool isOnStair;
    
    void Update()
    {
        if (isOnStair)
        {
            upInput = Input.GetAxis("Vertical");
            otherOn.gameObject.transform.Translate( Vector2.up *  upInput * speed );
        }
    }
    // collider = GetComponent<CapsuleCollider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            other.isTrigger = isOnStair = true;
            otherOn = other;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            other.isTrigger = isOnStair = false;
            otherOn = null;
        }
    }

}
