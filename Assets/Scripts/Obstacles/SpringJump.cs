using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : JumpOtherOnCollision
{
    SpriteRenderer spriteRdrr;
    [SerializeField] Sprite[] sprites = new Sprite[2];

    protected override void Awake()
    {
        spriteRdrr = GetComponent<SpriteRenderer>();
        jumpForce = 300;
        base.Awake();
    }

    protected override void OnCollisionTopEnter(Collision2D other) {
        collider.offset = Vector2.down * 0.25f;
        spriteRdrr.sprite = sprites[1];
        base.OnCollisionTopEnter(other);
    }

    protected override void OnCollisionTopExit(Collision2D other) {
        spriteRdrr.sprite = sprites[0];
        collider.offset = Vector2.up * 0.25f;
    }
}
