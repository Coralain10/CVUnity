using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : JumpOtherOnCollision
{
    SpriteRenderer spriteRdrr;
    [SerializeField] Sprite[] sprites = new Sprite[2];

    protected override void Awake() {
        spriteRdrr = GetComponent<SpriteRenderer>();
        jumpForce = 300;
        base.Awake();
    }

    protected override void OnCollisionEnter2D(Collision2D other) {
        spriteRdrr.sprite = sprites[1];
        base.OnCollisionEnter2D(other);
    }

    protected override IEnumerator returnToFull(Collision2D other) {
        yield return base.returnToFull(other);
        spriteRdrr.sprite = sprites[0];
    }
}
