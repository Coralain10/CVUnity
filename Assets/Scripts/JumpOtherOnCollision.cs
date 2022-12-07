using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(TouchingDirections))]
public class JumpOtherOnCollision : MonoBehaviour
{
    public float jumpForce = 300;
    protected CapsuleCollider2D collider;
    [SerializeField] Vector2 startPositionLeft, startPositionRight;
    RaycastHit2D hitLeft, hitRight;

    protected virtual void Awake()
    {
        collider = GetComponent<CapsuleCollider2D>();
        float halfWidth = collider.size.x * transform.localScale.x / 2.0f;
        float padding = 0.33f;
        float topOffset = 0.55f;
        startPositionLeft = (Vector2) transform.position + new Vector2(-halfWidth+padding, topOffset);
        startPositionRight = (Vector2) transform.position + new Vector2(halfWidth-padding, topOffset);
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        float laserLength = 0.05f;
        hitLeft = Physics2D.Raycast(startPositionLeft, Vector2.up, laserLength);
        hitRight = Physics2D.Raycast(startPositionRight, Vector2.up, laserLength);
        if (hitLeft.collider != null || hitRight.collider != null)
        {
            OnCollisionTopEnter(other);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (hitLeft.collider != null || hitRight.collider != null)
        {
            OnCollisionTopExit(other);
        }
    }

    protected virtual void OnCollisionTopEnter(Collision2D other)
    {
        other.rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    protected virtual void OnCollisionTopExit(Collision2D other) {
    }

}
