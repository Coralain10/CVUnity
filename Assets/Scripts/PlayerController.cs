using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] short speed = 16;
    TouchingDirections touchingDirections;
    float forwardInput;
    [SerializeField] float gravityScale = 4;
    [SerializeField] float gravityFallScale = 12;
    [SerializeField] float jumpMaxHeight = 2.5f;
    [SerializeField] float jumpMinHeight = 1.25f;
    [SerializeField] float jumpMaxDistance = 1;
    [SerializeField] float jumpCurrHeight;
    [SerializeField] float jumpCurrDistance;
    [SerializeField] float jumpFirstPosition;
    [SerializeField] float jumpForce;
    [SerializeField] private bool isGameOver;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool changedDirection;

    public bool useForce = true; //TODO: Check whats best

    void Awake()
    {
        isGameOver = false;
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        resetJump();
    }

    void FixedUpdate() {
        if (!isGameOver) {
            setFacingDirection();
            Move();
            Jump();
        }
    }
    void setFacingDirection () {
        forwardInput = Input.GetAxis("Horizontal");
        if (forwardInput > 0 && !isFacingRight) {
            isFacingRight = true;
            changedDirection = true;
        } else if (forwardInput < 0 && isFacingRight) {
            isFacingRight = false;
            changedDirection = true;
        } else {
            changedDirection = false;
        }
    }

    void Move()
    {
        if (touchingDirections.IsOnGround) {
            rb.velocity = new Vector2(forwardInput * speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(forwardInput * (speed/2), rb.velocity.y);
        }
    }

    void Jump() {
        //TODO: FIX sometimes not jumping, sometimes jumping too high
        if (touchingDirections.IsOnGround) {
            //Impultso para saltar según cuánto corrió
            if (changedDirection || rb.velocity.x == 0) { resetJump(); }
            else if (jumpCurrDistance < jumpMaxDistance && Input.GetButton("Horizontal")) {
                jumpCurrDistance = Mathf.Min(Mathf.Abs(transform.position.x - jumpFirstPosition), jumpMaxDistance);
            }

            //si inicia salto
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb.gravityScale = gravityScale;
                jumpCurrHeight = Mathf.Max(jumpMaxHeight * (jumpCurrDistance/jumpMaxDistance), jumpMinHeight);
                jumpForce = Mathf.Sqrt( jumpCurrHeight * -2 * (Physics2D.gravity.y * rb.gravityScale)) * rb.mass;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                resetJump();
            }
        }
        if (rb.velocity.y < 0) {
            rb.gravityScale = gravityFallScale;
        }
    }

    void resetJump() {
        jumpCurrDistance = 0;
        jumpFirstPosition = transform.position.x;
    }

    void OnCollisionEnter2D(Collision2D col) {
        // if (col.gameObject.CompareTag("Ground")) {
        //     isOnGround = true;
        // }
    }
}
