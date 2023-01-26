using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CollisionOnTop : MonoBehaviour
{
    Vector2 startPosition, endPosition;
    protected Collider2D col;
    public bool isOnTop { protected set; get; }
    float padding = 0.1f;
    float topOffset = 0.55f;
    float halfWidth;

    protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
        // float halfWidth = col.size.x * transform.localScale.x / 2.0f;
        halfWidth = col.bounds.size.x * transform.localScale.x / 2.0f;
        isOnTop = false;
        SetCollisionTopRange();
    }

    public void SetCollisionTopRange()
    {
        startPosition = (Vector2) transform.position + new Vector2(-halfWidth+padding, topOffset);
        endPosition = (Vector2) transform.position + new Vector2(halfWidth-padding, topOffset);
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

    protected virtual void OnCollisionTopEnter(Collision2D other) { }

    protected virtual void OnCollisionTopExit(Collision2D other) { }
}
