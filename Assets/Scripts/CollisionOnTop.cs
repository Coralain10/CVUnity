using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CollisionOnTop : MonoBehaviour
{
    protected Collider2D collider;
    protected bool isOnTop;
    Vector2 startPosition, endPosition;

    protected virtual void Awake()
    {
        collider = GetComponent<Collider2D>();
        // float halfWidth = collider.size.x * transform.localScale.x / 2.0f;
        float halfWidth = collider.bounds.size.x * transform.localScale.x / 2.0f;
        float padding = 0.1f;
        float topOffset = 0.55f;
        startPosition = (Vector2) transform.position + new Vector2(-halfWidth+padding, topOffset);
        endPosition = (Vector2) transform.position + new Vector2(halfWidth-padding, topOffset);
        isOnTop = false;
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        //Physics2D.OverlapBox
        if ( Physics2D.Linecast(startPosition, endPosition) )
        {
            isOnTop = true;
            OnCollisionTopEnter(other);
            Debug.DrawRay(startPosition, endPosition, Color.red);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (isOnTop)
        {
            OnCollisionTopExit(other);
            isOnTop = false;
        }
    }

    protected virtual void OnCollisionTopEnter(Collision2D other)
    {
    }

    protected virtual void OnCollisionTopExit(Collision2D other) {
    }
}
