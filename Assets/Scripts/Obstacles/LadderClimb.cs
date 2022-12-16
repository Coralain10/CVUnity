using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController player;
    short speed = 16;
    float hopJump = 4;
    float verticalInput;
    float gravityScale;
    bool isClimbing;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        gravityScale = rb.gravityScale;
    }
    
    void Update()
    {
        if (player.isOnLadder) CheckClimb();
    }
    // collider = GetComponent<CapsuleCollider2D>();

    void FixedUpdate()
    {
        if (player.isOnLadder) ClimbStair();
    }

    void CheckClimb()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(verticalInput) > 0f)
        {
            isClimbing = true;
        }
    }

    void ClimbStair()
    {
        if (isClimbing)
        {
            rb.velocity = new Vector2( rb.velocity.x, verticalInput * speed );
        }
        // otherRb.gameObject.transform.Translate( Vector2.up *  verticalInput * speed );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            player.isOnLadder = true;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2( rb.velocity.x, 0 );
            getLadderTopBlock(other).enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            if (verticalInput > 0)
            {
                rb.velocity = new Vector2( rb.velocity.x, hopJump );
            }
            rb.gravityScale = gravityScale;
            player.isOnLadder = isClimbing = false;
            getLadderTopBlock(other).enabled = true;
        }
    }

    BoxCollider2D getLadderTopBlock(Collider2D ladder) {
        return ladder.transform.Find("Block").gameObject.GetComponent<BoxCollider2D>();
    }
    

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     // Debug.Log(other.tag);
    //     if (other.CompareTag("Stair"))
    //     {
    //         isOnLadder = true;
    //     }
    // }
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     // Debug.Log(other.tag);
    //     if (other.CompareTag("Stair"))
    //     {
    //         isOnLadder = isClimbing = false;
    //     }
    // }

}
