using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    short speed = 16;
    float forwardInput;
    float airResistance = 2f;
    float jumpMaxHeight = 2.5f;
    float jumpMinHeight = 1.25f;
    float jumpMaxDistance = 1.5f;
    float jumpCurrHeight;
    float jumpCurrDistance;
    float jumpFirstPosition;
    float jumpForce;
    bool isJumping;
    bool isGameOver;
    bool isFacingRight;
    bool changedDirection;

    public bool useForce = true; //TODO: Check whats best

    void Awake()
    {
        isGameOver = false;
        isFacingRight = true;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        resetJump();
    }

    void FixedUpdate()
    {
        if (isJumping) 
        {
            Jump();
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            setFacingDirection();
            Move();
            CheckJump();
        }
    }

    void setFacingDirection ()
    {
        forwardInput = Input.GetAxis("Horizontal");
        if (forwardInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            changedDirection = true;
        }
        else if (forwardInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            changedDirection = true;
        }
        else
        {
            changedDirection = false;
        }
    }

    void Move()
    {
        if (touchingDirections.IsOnGround)
        {
            rb.velocity = new Vector2(forwardInput * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(forwardInput * (speed/airResistance), rb.velocity.y);
        }
    }

    void CheckJump() {
        if (touchingDirections.IsOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
            }

            if ( changedDirection || rb.velocity.x == 0 )
            {
                resetJump();
            }

            //Impultso para saltar según cuánto corrió
            jumpCurrDistance = Mathf.Min( Mathf.Abs(transform.position.x - jumpFirstPosition), jumpMaxDistance );
        }
    }

    void Jump()
    {
        jumpCurrHeight = Mathf.Max(jumpMaxHeight * (jumpCurrDistance/jumpMaxDistance), jumpMinHeight);
        jumpForce = Mathf.Sqrt( jumpCurrHeight * -2 * (Physics2D.gravity.y * rb.gravityScale)) * rb.mass;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = false;
        resetJump();
    }

    void resetJump() {
        jumpCurrDistance = 0;
        jumpFirstPosition = transform.position.x;
    }

    // void OnCollisionEnter2D(Collision2D col) {
    //     // if (col.gameObject.CompareTag("Ground")) {
    //     //     isOnGround = true;
    //     // }
    // }
}
