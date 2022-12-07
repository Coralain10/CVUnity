using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(CapsuleCollider2D))]
public class JumpOtherOnCollision : CollisionOnTop
{
    public float jumpForce = 24;
    // protected CapsuleCollider2D collider;

    protected override void Awake()
    {
        base.Awake();
        // collider = GetComponent<CapsuleCollider2D>();
    }

    protected override void OnCollisionTopEnter(Collision2D other)
    {
        other.rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
