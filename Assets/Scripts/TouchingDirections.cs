using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter; //check the raycasted object
    CapsuleCollider2D col;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    
    float groundDistance = 0.05f;
    public bool IsOnGround { get; private set; }
    public bool IsOnSides { get; private set; }

    void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        //Cast detects the number of collisions that the cast detected
        IsOnGround = col.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnSides = col.Cast(Vector2.right, castFilter, groundHits, groundDistance) > 0
                || col.Cast(Vector2.left, castFilter, groundHits, groundDistance) > 0;
    }
}
