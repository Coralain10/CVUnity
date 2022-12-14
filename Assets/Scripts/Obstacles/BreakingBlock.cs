using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBlock : MonoBehaviour
{
    enum State : byte { Complete, Breaking, Broken, Dissipated };
    [SerializeField] float timePerState = 0.5f;
    [SerializeField] State state;
    [SerializeField] bool smthOn;
    SpriteRenderer spriteRdr;
    public Sprite[] sprites = new Sprite[3];
    BoxCollider2D boxCollider2D;
    
    void Awake()
    {
        spriteRdr = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        state = State.Complete;
        spriteRdr.sprite = sprites[(int)state];
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        smthOn = true;
        StartCoroutine(BreakBlock());
    }
    void OnCollisionLeave2D(Collision2D other) {
        smthOn = false;
        StartCoroutine(RecoverBlock());
    }

    IEnumerator BreakBlock() {
        while ( smthOn ) {
            yield return new WaitForSeconds(timePerState);
            if (state < State.Dissipated)
            {
                state++;
                ActOnState();
            }
        }
        yield return null;
    }
    IEnumerator RecoverBlock() {
        while ( !smthOn ) {
            yield return new WaitForSeconds(timePerState);
            if (state > State.Complete)
            {
                state--;
                ActOnState();
            }
        }
        yield return null;
    }
    
    void ActOnState() {
        switch (state)
        {
            case State.Broken:
                spriteRdr.enabled = true;
                boxCollider2D.isTrigger = false;
                break;
            case State.Dissipated:
                smthOn = false;
                spriteRdr.enabled = false;
                boxCollider2D.isTrigger = true;
                StartCoroutine(RecoverBlock());
                break;
        }
        if (state < State.Dissipated) spriteRdr.sprite = sprites[(int)state];
    }
}
