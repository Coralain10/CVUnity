using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(CapsuleCollider2D), typeof(TouchingDirections))]
public class JumpOtherOnCollision : MonoBehaviour
{
    protected float jumpForce = 300;
    CapsuleCollider2D collider;
    // TouchingDirections touchingDirections;

    protected virtual void Awake()
    {
        collider = GetComponent<CapsuleCollider2D>();
        // touchingDirections = GetComponent<TouchingDirections>();
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        // if (touchingDirections.IsOnTop) 
        collider.transform.Translate(Vector2.down * 0.5f);
        other.rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        StartCoroutine( returnToFull(other) );
    }

    protected virtual IEnumerator returnToFull(Collision2D other) {
        yield return new WaitForSeconds(Time.deltaTime * 2);
        collider.transform.Translate(Vector2.up * 0.5f);
    }
}
