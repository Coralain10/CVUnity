using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public LiveArray liveArr;
    public ParticleSystem bloodParticle;
    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    short speed = 16;
    float horizontalInput;
    // float maxFallingVelocity = -10f;
    float jumpFirstPosition;
    bool isDying;
    bool isJumping;
    // bool didFallHigh;
    public bool isOnLadder;
    
    bool _isFacingRight;
    public bool IsFacingRight
    {
        get => _isFacingRight;
        private set
        {
            _isFacingRight = value;
            transform.localScale *= new Vector2(-1,1);
        }
    }


    void Awake()
    {
        touchingDirections = GetComponent<TouchingDirections>();
        rb = GetComponent<Rigidbody2D>();
        _isFacingRight = true;
        isJumping = false;
        isOnLadder = false;
        // didFallHigh = false;
    }

    void FixedUpdate()
    {
        if (isJumping) Jump();
    }

    void Update()
    {
        if (!liveArr.lostAllLives)
        {
            setFacingDirection();
            CheckJump();
            Move();
        }
    }

    void setFacingDirection ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (horizontalInput < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }
    
    void Move()
    {
        if (touchingDirections.IsOnGround)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
            // didFallHigh = false;
        }
        else
        {
            float airResistance = 2f;
            rb.velocity = new Vector2(horizontalInput * (speed/airResistance), rb.velocity.y);
            // if (!didFallHigh && rb.velocity.y < maxFallingVelocity && !isOnLadder) //velocity.y keeps decreasing
            // {
            //     gotDamage();
            //     didFallHigh = true;
            // }
        }
    }

    void CheckJump() {
        if (touchingDirections.IsOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
            }

            if ( rb.velocity.x == 0 )
            {
                jumpFirstPosition = transform.position.x;
            }
        }
    }
    void Jump()
    {
        //Impulso para saltar según cuánto corrió
        float jumpMaxDistance = 1.5f;
        float jumpCurrDistance = Mathf.Min( Mathf.Abs(transform.position.x - jumpFirstPosition), jumpMaxDistance );
        float jumpMaxHeight = 2.5f, jumpMinHeight = 1.25f;
        float jumpCurrHeight = Mathf.Max(jumpMaxHeight * (jumpCurrDistance/jumpMaxDistance), jumpMinHeight);
        float jumpForce = Mathf.Sqrt( jumpCurrHeight * -2 * (Physics2D.gravity.y * rb.gravityScale)) * rb.mass;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = false;
    }

    void gotDamage()
    {
        bloodParticle.Play();
        liveArr.SetDamage();
        if (liveArr.lostAllLives)
        {
            isDying = false;
            Debug.Log("GAME OVER");
        }
    }

    IEnumerator Dying() {
        while (isDying) {
            gotDamage();
            yield return new WaitForSeconds(0.25f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            isDying = true;
            StartCoroutine( Dying() );
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            isDying = false;
            liveArr.Recover();
        }
    }
}
