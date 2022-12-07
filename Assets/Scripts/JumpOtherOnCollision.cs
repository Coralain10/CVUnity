using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class JumpOtherOnCollision : MonoBehaviour
{
    public float jumpForce = 300;
    protected CapsuleCollider2D collider;
    [SerializeField] Vector2 startPosition, endPosition;
    bool isOnTop;

    protected virtual void Awake()
    {
        collider = GetComponent<CapsuleCollider2D>();
        float halfWidth = collider.size.x * transform.localScale.x / 2.0f;
        float padding = 0.1f;
        float topOffset = 0.55f;
        startPosition = (Vector2) transform.position + new Vector2(-halfWidth+padding, topOffset);
        endPosition = (Vector2) transform.position + new Vector2(halfWidth-padding, topOffset);
        isOnTop = false;
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if ( Physics2D.Linecast(startPosition, endPosition) )
        {
            isOnTop = true;
            OnCollisionTopEnter(other);
            // Debug.DrawRay(startPosition, endPosition, Color.red);
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
        other.rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    protected virtual void OnCollisionTopExit(Collision2D other) {
    }

}
